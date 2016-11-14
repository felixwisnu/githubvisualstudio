using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Retrieve
{
    public static class log
    {
        public static void WriteErrorLog(Exception ex)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLog.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + ": " + ex.Source.ToString().Trim() + "; " + ex.Message.ToString().Trim());
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }

        public static void WriteErrorLog(string Message)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Log.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + ": " + Message);
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }

        

        public static string error(string err)
        {
            string eror = "";
            if (err == "-100")
            {
                eror = "Operation failed or data not exist";
                
            }
            else if (err == "-10")
            {
                eror = "Transmitted data length is incorrect";

            }
            else if (err == "-5")
            {
                eror = "Operation failed or data not exist";

            }
            else if (err == "-4")
            {
                eror = "Data already exists";

            }
            else if (err == "-3")
            {
                eror = "Space is not enough";

            }
            else if (err == "-2")
            {
                eror = "Error in file read/write";

            }
            else if (err == "-1")
            {
                eror = "SDK is not initialized and needs to be reconnected";

            }
            else if (err == "0")
            {
                eror = "Data not found or data repeated";

            }
            else if (err == "1")
            {
                eror = "Operation is correct";

            }
            else if (err == "4")
            {
                eror = "Parameter is incorrect";

            }
            else if (err == "101")
            {
                eror = "Error in allocating buffer";
                
            }
            return eror;
        }
    }
}
