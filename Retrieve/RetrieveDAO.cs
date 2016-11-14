using System.Data.SQLite;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace Retrieve
{
    public class RetrieveDAO
    {
        //private DataTable dtmdb;
        private SQLiteConnection conserver = new SQLiteConnection();
        //private MySqlConnection consql = new MySqlConnection();
        //private OleDbConnection conmdb= new OleDbConnection();
        //private OleDbCommand oleDbCmd = new OleDbCommand();
        //private string constringsql;
        //private string constringmdb; 
        private string constringserver;

        public RetrieveDAO()
        {
            constringserver = ConfigurationManager.AppSettings["dbsqlite"];
            //constringserver = ConfigurationManager.ConnectionStrings["conserver"].ConnectionString;
            conserver = new SQLiteConnection(constringserver);
        }

        //public terminal GetAllTerminal(int cab)
        //{
        //    terminal ter = new terminal();
        //    StringBuilder query = new StringBuilder(@"select terminal_id AS 'TerminalID', kode_cabang AS 'KodeCabang', nama_cabang as 'NamaCabang' from cabang where terminal_id = @cabang order by terminal_id asc");


        //    try
        //    {
        //        if (conserver.State == ConnectionState.Closed)
        //        {
        //            conserver.Open();
        //        }

        //        MySqlCommand com = new MySqlCommand(query.ToString(), conserver);
        //        com.Parameters.AddWithValue("@cabang", cab);
        //        MySqlDataReader Reader;

        //        Reader = com.ExecuteReader();
        //        if (Reader.Read())
        //        {
        //            ter.TerminalId = Reader.GetInt32(0);
        //            ter.KodeCabang = Reader.GetString(1);
        //            ter.NamaCabang = Reader.GetString(2);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.WriteErrorLog("getTerminalDAO* "+ex.Message);
        //        //ex.ToString();
        //    }

        //    finally
        //    {
        //        if (conserver.State == ConnectionState.Open)
        //        {
        //            conserver.Close();
        //        }
        //    }
        //    return ter;

        //}

       

        public DataTable readDataMySqlDBbyTerminal(int terminal)
        {
            DataTable tblSrc = new DataTable();
            //StringBuilder query = new StringBuilder(@"SELECT id_cabang as 'TerminalID', nik as 'FingerPrintID', clock as 'DateTime', status as 'FunctionKey' FROM `coba` where id_cabang = @ter");
            //StringBuilder query = new StringBuilder(@"SELECT id_cabang as 'TerminalID', nik as 'FingerPrintID', clock as 'DateTime', status as 'FunctionKey' FROM `fp` where manual = 'N' and id_cabang = @ter");
            //StringBuilder query = new StringBuilder(@"SELECT id_cabang as 'TerminalID', nik as 'FingerPrintID', clock as 'DateTime', status as 'FunctionKey' FROM `fp` where manual = 'N' and id_cabang = @ter and clock >= now()-interval 3 month");
            StringBuilder query = new StringBuilder(@"SELECT cabang as 'TerminalID', nik as 'FingerPrintID', clock as 'DateTime', status as 'FunctionKey' FROM `fp` where cabang = @ter");
            try
            {
                if (conserver.State == ConnectionState.Closed)
                {
                    conserver.Open();
                }

                SQLiteCommand com = new SQLiteCommand(query.ToString(), conserver);
                com.Parameters.AddWithValue("@ter", terminal );
                SQLiteDataAdapter adap = new SQLiteDataAdapter(com);
                adap.Fill(tblSrc);
            }
            catch (Exception ex)
            {
                log.WriteErrorLog("readDataDAO* " + ex.Message + "on terminal" + terminal);       
            }

            finally
            {
                if (conserver.State == ConnectionState.Open)
                {
                    conserver.Close();
                }
            }
            return tblSrc;

        }

        //public string getLastDate(int terminal)
        //{
        //    string lastdate = string.Empty;
        //    var query = new StringBuilder(@"select MAX(clock) as lastdate from fp where manual = 'N' and id_cabang = @ter");

        //    try
        //    {
        //        if (conserver.State == ConnectionState.Closed)
        //        {
        //            conserver.Open();
        //        }

        //        var com = new MySqlCommand(query.ToString(), conserver);
        //        com.Parameters.AddWithValue("@ter", terminal);
        //        MySqlDataReader Reader = com.ExecuteReader();

        //        if (Reader.Read())
        //        {
        //            DateTime las = Convert.ToDateTime(Reader.GetValue(0));
        //            lastdate = String.Format("{0:f}", las);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.WriteErrorLog(ex.Message);
        //    }

        //    finally
        //    {
        //        if (conserver.State == ConnectionState.Open)
        //        {
        //            conserver.Close();
        //        }
        //    }
        //    return lastdate;
        //}
    }
}
