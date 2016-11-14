using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Timers;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;
using zkemkeeper;
using Timer = System.Timers.Timer;

namespace Retrieve
{
    public partial class RetrieveUI : Form
    {
        private readonly int TanggalBackUp;
        private readonly int commPass;
        //private readonly MySqlConnection conserver = new MySqlConnection();
        private readonly int port;
        private readonly RetrieveDAO reDAO;
        private readonly terminal ter;
        private bool Connect;
        private DataTable DataFP;
        private int RowsFP;
        private absen abs;
        private int cabang;
        private string constringserver;
        private DataTable dataSQL;
        private DataTable dtTerminal = new DataTable();
        private int h;
        private string hour = string.Empty;
        private int i = 0;
        private int iGLCount;
        private int iIndex;
        private int iMachineNumber = 1;
        private int ip = 0;
        private string lastBackUP;
        private int m;
        private int max;
        private string minute = string.Empty;
        public CZKEMClass sdk = new CZKEMClass();
        private SaveFileDialog svDialog;

        private string tickH = string.Empty;
        private string tickM = string.Empty;
        private Timer _timer;
        private int y;
        private int z;

        private int tmr = 0;

        private readonly SQLiteConnection conserver;// = new SQLiteConnection();

        public RetrieveUI()
        {
            InitializeComponent();
            reDAO = new RetrieveDAO();
            ter = new terminal();
            abs = new absen();

            //string tempComm = ;

            port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            commPass = Convert.ToInt32(ConfigurationManager.AppSettings["commPass"]);
            cabang = Convert.ToInt32(ConfigurationManager.AppSettings["cabang"]);
            constringserver = ConfigurationManager.AppSettings["dbsqlite"];
            lastBackUP = ConfigurationManager.AppSettings["lastBackUp"];
            TanggalBackUp = Convert.ToInt32(ConfigurationManager.AppSettings["setTanggalBackUp"]);
            conserver = new SQLiteConnection(constringserver);

            //ter = GetAllTerminal(cabang);
            setView();
        }


        private static void setAppConfig(string key, string value)
        {
            Configuration configuration =
                ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Shift | Keys.Z))
            {
                DialogResult dialogResult = MessageBox.Show("Anda yakin ingin restart mesin FP ???", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    log.WriteErrorLog("The device will restart....");

                    restartDevice();
                    log.WriteErrorLog("Program restart...");
                    Application.Restart();

                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void timerRestartStart()
        {
            
	        //_l = new List<DateTime>(); // Allocate the list
	        _timer = new Timer(1000); // Set up the timer for 3 seconds
	        //
	        // Type "_timer.Elapsed += " and press tab twice.
	        //
            _timer.Elapsed += (_timer_Elapsed);
	        _timer.Enabled = true; // Enable it
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            tmr++;

            if (tmr == 20)
            {
                //btnManual.Enabled = true;
                //MessageBox.Show("Success device restart!", "Success");
                _timer.Stop(); //; = false;
                _timer.Enabled = false;

                StartServiceManually();
            }
            

        }

        private void restartDevice()
        {
            sdk.SetCommPassword(commPass);
            string con = "192.168." + ter.TerminalId + ".150";
            Connect = sdk.Connect_Net(con, port);

            sdk.PlayVoice(5, 10);
            sdk.EnableDevice(iMachineNumber, false);
            btnManual.Enabled = false;
            Cursor = Cursors.WaitCursor;
            if (sdk.RestartDevice(iMachineNumber))
            {
                MessageBox.Show("The device will restart!", "Success");
            }
            else
            {
                log.WriteErrorLog("Success device restart...");
            }
        }

        private void setView()
        {
            lblTerminalID.Text = ter.TerminalId.ToString();
            lblKodeCabang.Text = ter.KodeCabang;
            lblNamaCabang.Text = ter.NamaCabang;
            //lblLastRetrieve.Text = reDAO.getLastDate(ter.TerminalId);
            DateTime last = Convert.ToDateTime(lastBackUP);
            lblLastBackUp.Text = String.Format("{0:f}", last);
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            if (Connect)
            {
                sdk.Disconnect();
                Connect = false;
            }

            clear();
            StartServiceManually();
            Cursor = Cursors.Default;
        }

        //public terminal GetAllTerminal(int cab)
        //{
        //    var ter = new terminal();
        //    try
        //    {
        //        //dtTerminal = new DataTable();
        //        ter = reDAO.GetAllTerminal(cab);
        //        //dgvTerminal.DataSource = dtTerminal;
        //    }
        //    catch (Exception ex)
        //    {
        //        log.WriteErrorLog("@getTerminal* " + ex.Message);
        //    }
        //    return ter;
        //}

        private void StartServiceManually()
        {
            //Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (ping(cabang.ToString()))
                {
                    //restartDevice();
                    //lblStatus.Text = "Wait Device restart...";
                    //Thread.Sleep(3000);

                    int term = ter.TerminalId;
                    dataSQL = new DataTable();
                    dataSQL = reDAO.readDataMySqlDBbyTerminal(cabang);
                    getAllDataByManually(dataSQL, cabang.ToString());
                    //Cursor = Cursors.Default;
                }
                else
                {
                    log.WriteErrorLog("Tidak dapat terkoneksi ke mesin...!!!");
                    log.WriteErrorLog("Program keluar...!!!");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                log.WriteErrorLog("@StartServiceManually* " + ex.Message);
            }
            finally
            {
                btnManual.Enabled = true;
                //lblLastRetrieve.Text = reDAO.getLastDate(ter.TerminalId);

                lastBackUP = ConfigurationManager.AppSettings["lastBackUp"];
                DateTime last = Convert.ToDateTime(lastBackUP);
                lblLastBackUp.Text = String.Format("{0:f}", last);

                Cursor = Cursors.Default;
            }
        }


        private void getAllDataByManually(DataTable dtserver, string ter)
        {
            var ser = new DataTable();
            SQLiteTransaction trans = null;
            var comm = new SQLiteCommand();

            abs = new absen();
            ser = dtserver;

            try
            {
                List<DataRow> listSql = ser.AsEnumerable().ToList();
                List<DataRow> tempserver = listSql.ToList();

                int idwErrorCode = 0;


                sdk.SetCommPassword(commPass);
                string con = "192.168." + ter + ".150";
                Connect = sdk.Connect_Net(con, port);

                //MESIN FP

                if (!Connect)
                {
                    SetStatus("Failed to connect");
                    log.WriteErrorLog("Failed to connect...!!!");
                }
                else
                {
                    //sdk.PlayVoice(5, 10);
                    SetStatus("Connected");
                    log.WriteErrorLog("Connected...");

                    iMachineNumber = 1;

                    int idwTMachineNumber = 0;
                    string sdwEnrollNumber = "";
                    int idwEMachineNumber = 0;
                    int idwVerifyMode = 0;
                    int idwInOutMode = 0;
                    int idwYear = 0;
                    int idwMonth = 0;
                    int idwDay = 0;
                    int idwHour = 0;
                    int idwMinute = 0;

                    int idwWorkcode = 0;
                    int idwSecond = 0;

                    //int idwErrorCode = 0;
                    int iGM = 0;
                    int iIndexM = 0;

                    //Cursor.Current = Cursors.WaitCursor;
                    //lvLogs.Items.Clear();

                    sdk.RegEvent(sdk.MachineNumber, 65535);
                    //sdk.EnableDevice(iMachineNumber, false); //disable the device
                    sdk.DisableDeviceWithTimeOut(iMachineNumber, 120);


                    /////////////////// get count log FP
                    int iValue = 0;
                    if (sdk.GetDeviceStatus(iMachineNumber, 6, ref iValue))
                        //Here we use the function "GetDeviceStatus" to get the record's count.The parameter "Status" is 6.
                    {
                        log.WriteErrorLog("The count of the AttLogs in the device is " + iValue);
                        RowsFP = iValue;
                    }

                    if (RowsFP != 0)
                    {
                        /////////////////// read all the attendance records to the memory

                        log.WriteErrorLog("Read att log...");
                        var dtTemp = new DataTable();
                        if (sdk.ReadAllGLogData(iMachineNumber))
                        {
                            //dtTemp = new DataTable();
                            dtTemp.Columns.Add("No.");
                            dtTemp.Columns.Add("TerminalID");
                            dtTemp.Columns.Add("FingerPrintID");
                            dtTemp.Columns.Add("DateTime");
                            //dtTemp.Columns.Add("Time");
                            dtTemp.Columns.Add("FunctionKey");

                            while (sdk.SSR_GetGeneralLogData(sdk.MachineNumber, out sdwEnrollNumber, out idwVerifyMode,
                                out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute,
                                out idwSecond, ref idwWorkcode)) //get records from the memory
                            {
                                iGM++;

                                string tgl = idwYear + "-" + idwMonth + "-" + idwDay + " " + idwHour + ":" + idwMinute +
                                             ":" +
                                             idwSecond;

                                DateTime tempTgl = Convert.ToDateTime(tgl);

                                string datetime = tempTgl.ToString("yyyy-MM-dd HH:mm:ss");
                                //string time = tempTgl.ToShortTimeString();

                                dtTemp.Rows.Add(iGM, ter, sdwEnrollNumber, datetime, idwInOutMode.ToString());
                            }
                            iGM = 0;
                        }
                        else
                        {
                            log.WriteErrorLog("Failed Read att log...!!!");
                        }

                        y = 0;
                        z = 0;

                        iGLCount = 0;
                        iIndex = 0;

                        //////////////////////////Connect To Server
                        if (conserver.State == ConnectionState.Closed)
                        {
                            log.WriteErrorLog("Server Open...");
                            conserver.Open();
                        }
                        trans = conserver.BeginTransaction();
                        comm.Transaction = trans;


                        DateTime last3month = DateTime.Now.AddMonths(-3);
                        DateTime tempTgls = Convert.ToDateTime(last3month.ToString("yyyy-MM-dd HH:mm:ss"));

                        //DateTime datetime = tempTgls.ToString("yyyy-MM-dd HH:mm:ss");

                        var ds = new DataSet();
                        ds.Tables.Add(dtTemp);
                        //var dt3month = new DataTable();

                        log.WriteErrorLog("Ambil data log 3 bulan terakhir...");

                        DataTable dt3month =
                            ds.Tables[0].Select()
                                .Where(p => (Convert.ToDateTime(p["DateTime"]) > tempTgls))
                                .CopyToDataTable();

                        log.WriteErrorLog("Date last3month : " + last3month);
                        log.WriteErrorLog("Data All on FP : " + dtTemp.Rows.Count);
                        log.WriteErrorLog("Data last3month on FP : " + dt3month.Rows.Count);
                        log.WriteErrorLog("Data last3month on Server : " + tempserver.Count);

                        max = dt3month.Rows.Count;
                        SetTotalTextManual(max.ToString());


                        log.WriteErrorLog("Insert data ke server...");
                        foreach (DataRow x in dtTemp.AsEnumerable())
                        {
                            //bool result = false;
                            abs = new absen();
                            int tempFP = 0;
                            tempFP = Convert.ToInt32(x["FingerPrintID"]);
                            abs.TerminalID = x["TerminalID"].ToString();
                            abs.FingerPrintID = tempFP.ToString().Trim();
                            abs.Datetime = Convert.ToDateTime(x["DateTime"].ToString());
                            abs.FunctionKey = x["FunctionKey"].ToString().Trim();

                            //SetLog(abs);

                            //foreach (DataRow xx in tempserver.AsEnumerable())
                            //{
                            //    string id = xx["FingerPrintID"].ToString();
                            //    DateTime tgl = Convert.ToDateTime(xx["DateTime"].ToString());
                            //    if (!(tgl == abs.Datetime && id == abs.FingerPrintID))
                            //    {
                                    
                            //    }
                            //    else
                            //    {
                                    
                            //    }
                            //}


                            var result = from r in ser.AsEnumerable()
                                                          where r.Field<string>("FingerPrintID") == abs.FingerPrintID &&
                                                                r.Field<string>("DateTime") == abs.Datetime.ToString()
                                                          select r;

                            if (!(result.Count() > 0))
                            {
                                comm = new SQLiteCommand(@"INSERT INTO fp( nik, clock, status, cabang) VALUES(@fingerprint_id,@date_time,@functionkey,@terminal_id)", conserver);

                                    comm.CommandTimeout = 12000; //result.AsEnumerable().Count();
                                    comm.Parameters.AddWithValue("@terminal_id", abs.TerminalID);
                                    comm.Parameters.AddWithValue("@fingerprint_id", abs.FingerPrintID);
                                    comm.Parameters.AddWithValue("@date_time", abs.Datetime);
                                    comm.Parameters.AddWithValue("@functionkey", abs.FunctionKey);
                                    comm.ExecuteNonQuery();

                                    y++;
                                    SetSuccessText(y.ToString());
                                    //SetProgressBarText(y);
                                    SetLog(abs);
                            }
                            else
                            {
                                z++;
                                SetExistText(z.ToString());
                                //SetProgressBarText(z);
                            }
                        }

                        trans.Commit();
                        comm.Dispose();

                        /////////////////////////// backup
                        if (DateTime.Today.Day == TanggalBackUp)
                        {
                            if (RowsFP != 0)
                            {
                                if (RowsFP == dtTemp.Rows.Count)
                                {
                                    log.WriteErrorLog("Backup Data...");
                                    if (BackupLogFP(dtTemp)) //////Backup FP
                                    {
                                        log.WriteErrorLog("BackUp berhasil...");
                                        //if (sdk.ClearGLog(iMachineNumber)) //Clear FP
                                        //{
                                        //    sdk.RefreshData(iMachineNumber);
                                        //    //the data in the device should be refreshed
                                        //    log.WriteErrorLog(
                                        //        "Att Log pada mesin berhasil dihapus...!!!");
                                        //}
                                        //else
                                        //{
                                        //    sdk.GetLastError(ref idwErrorCode);
                                        //    log.WriteErrorLog(
                                        //        "@getDataManually : - Gagal hapus : Operation failed,ErrorCode=" +
                                        //        idwErrorCode);
                                        //}
                                    }
                                    else
                                    {
                                        log.WriteErrorLog("Gagal BackUp Data...!!!");
                                    }
                                }
                                else
                                {
                                    log.WriteErrorLog("Jumlah Rows tidak sama !!!");
                                }
                            }
                            else
                            {
                                log.WriteErrorLog("Tidak ada data pada mesin !!!");
                            }
                        }
                        ///////////////////////////////////////////////////////////////
                    }
                    else
                    {
                        log.WriteErrorLog("@getDataManually : Tidak ada data pada mesin !!!");
                    }

                    //sdk.PlayVoice(5, 10);
                    //sdk.PlayVoice(5, 10);
                    //sdk.PlayVoice(5, 10);

                    sdk.EnableDevice(iMachineNumber, true);

                    sdk.Disconnect();
                    Connect = false;
                }
            }
            catch (Exception ex)
            {
                log.WriteErrorLog("@getDataManually : " + ex.Message);
                trans.Rollback();
            }
            finally
            {
                conserver.Close();
                log.WriteErrorLog("Penarikan Data selesai...");
                Cursor.Current = Cursors.Default;
            }
        }

        public bool BackupLogFP(DataTable dtLog) ////////////////////////////// backup FP
        {
            log.WriteErrorLog("Backup data sedang diproses...");
            bool success = false;
            try
            {
                var udisk = new UDisk();
                string filename = "BackUp data FP " + ter.KodeCabang.ToUpper() + " " + DateTime.Now.Day + "-" +
                                  DateTime.Now.Month + "-" + DateTime.Now.Year + "-" + DateTime.Now.Hour +
                                  DateTime.Now.Minute + ".dat";
                int iLength = 0;
                var byTemporaryBuf = new byte[1024*1024*40];


                int iTemBufIndex = 0;


                foreach (DataRow x in dtLog.AsEnumerable())
                {
                    abs = new absen();
                    int tempFP = 0;
                    tempFP = Convert.ToInt32(x["FingerPrintID"]);
                    abs.TerminalID = x["TerminalID"].ToString();
                    abs.FingerPrintID = tempFP.ToString().Trim();
                    abs.Datetime = Convert.ToDateTime(x["DateTime"].ToString());
                    abs.FunctionKey = x["FunctionKey"].ToString().Trim();

                    DateTime tempTgl = Convert.ToDateTime(abs.Datetime);

                    string dateTime = tempTgl.ToString("yyyy-MM-dd HH:mm:ss");

                    byte[] bySSRAttInfo = null;

                    int iOneLogLength = 0;
                    udisk.SetAttLogToDat(out bySSRAttInfo, out iOneLogLength, abs.FingerPrintID, dateTime,
                        abs.TerminalID, abs.FunctionKey, "0", "0");
                    Array.Copy(bySSRAttInfo, 0, byTemporaryBuf, iTemBufIndex, iOneLogLength);
                    iTemBufIndex += iOneLogLength;
                    iLength += iOneLogLength;
                }

                //System.IO.Directory.CreateDirectory(myDir);
                string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "backup", filename);

                var byDataBuf = new byte[iLength];
                Array.Copy(byTemporaryBuf, byDataBuf, iLength);

                File.WriteAllBytes(destPath, byDataBuf);
                //File.WriteAllBytes(svDialog.FileName, byDataBuf);

                setAppConfig("lastBackUp", DateTime.Now.ToString());
                return true;
            }
            catch (Exception ex)
            {
                log.WriteErrorLog("@BackupLogFP* " + ex.Message);
                return false;
            }
        }

        

        private bool ping(string ter)
        {
            var p = new Ping();
            PingReply r;
            string s;

            s = "192.168." + ter + ".150";

            r = p.Send(s);

            if (r.Status == IPStatus.Success)
            {
                log.WriteErrorLog("Ping to " + ter.ToUpper() + " [" + r.Address + "]" + " Successful"
                                  + " Response delay = " + r.RoundtripTime + " ms" + "\n");

                btnManual.Enabled = true;
                return true;
            }
            log.WriteErrorLog("@ping* Ping to " + ter + " Failed");
            MessageBox.Show("TIDAK DAPAT TERKONEKSI KE MESIN !!!");

            btnManual.Enabled = false;
            return false;
        }


        private void SetProgressBarText(int val)
        {
            if (progressBar1.InvokeRequired)
            {
                SetProgressBarCallback d = SetProgressBarText;
                Invoke(d, new object[] {val});
            }
            else
            {
                progressBar1.Value = (100*(y + z))/max;
            }
        }

        private void SetExistText(string text)
        {
            if (lblExists.InvokeRequired)
            {
                SetExistsTextCallback d = SetExistText;
                Invoke(d, new object[] {text});
            }
            else
            {
                lblExists.Text = text;
            }
        }


        private void SetSuccessText(string text)
        {
            if (lblRemaining.InvokeRequired)
            {
                SetSuccessTextCallback d = SetSuccessText;
                Invoke(d, new object[] {text});
            }
            else
            {
                lblRemaining.Text = text;
            }
        }

        //private void SetCurrentRow(int val)
        //{
        //    if (dgvTerminal.InvokeRequired)
        //    {
        //        SetLBTextCallback d = SetCurrentRow;
        //        Invoke(d, new object[] {val});
        //    }
        //    else
        //    {
        //        dgvTerminal.CurrentCell = dgvTerminal.Rows[val].Cells[0];

        //        lblTerminalID.Text = dgvTerminal.Rows[val].Cells["TerminalID"].Value.ToString();
        //        lblKodeCabang.Text = dgvTerminal.Rows[val].Cells["KodeCabang"].Value.ToString();
        //        lblNamaCabang.Text = dgvTerminal.Rows[val].Cells["NamaCabang"].Value.ToString();
        //    }
        //}

        private void SetTotalTextManual(string text)
        {
            if (lblTotal.InvokeRequired)
            {
                SetManualTotalTextCallback d = SetTotalTextManual;
                Invoke(d, new object[] {text});
            }
            else
            {
                lblTotal.Text = text;
            }
        }

        private void SetStatus(string text)
        {
            if (lblStatus.InvokeRequired)
            {
                SetStatusCallBack d = SetStatus;
                Invoke(d, new object[] {text});
            }
            else
            {
                lblStatus.Text = text;
            }
        }

        private void SetLog(absen abs)
        {
            if (lvLogs.InvokeRequired)
            {
                SetLogsCallback d = SetLog;
                Invoke(d, new object[] {abs});
            }
            else
            {
                iGLCount++;
                lvLogs.Items.Add(iGLCount.ToString());
                lvLogs.Items[iIndex].SubItems.Add(abs.TerminalID);
                lvLogs.Items[iIndex].SubItems.Add(abs.FingerPrintID);
                lvLogs.Items[iIndex].SubItems.Add(abs.Datetime.ToString());
                lvLogs.Items[iIndex].SubItems.Add(abs.FunctionKey);
                iIndex++;

                lvLogs.EnsureVisible(lvLogs.Items.Count - 1);
                lvLogs.Focus();
            }
        }

        private void clear()
        {
            lvLogs.Items.Clear();
            lblStatus.Text = "Disconnect";
            lblRemaining.Text = "0";
            lblExists.Text = "0";
            lblTotal.Text = "0";
            progressBar1.Value = 0;
            Cursor.Current = Cursors.Default;
        }



        private delegate void SetAktif(int i);

        private delegate void SetClear(int i);

        private delegate void SetExistsTextCallback(string text);

        private delegate void SetLBTextCallback(int val);

        private delegate void SetLogsCallback(absen abs);

        private delegate void SetManualTotalTextCallback(string text);

        private delegate void SetNonAktif(int i);

        private delegate void SetProgressBarCallback(int val);

        private delegate void SetStatusCallBack(string text);

        private delegate void SetSuccessTextCallback(string text);

        private void RetrieveUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            log.WriteErrorLog("Program keluar...");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }
    }
}