using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CheapTravel
{
    public class Logger
    {
        public static void WriteLog(string LogInput)
        {
            
            try
            {
                string path = System.IO.Directory.GetCurrentDirectory();
                string filepath = path + "\\wwwroot\\Log\\";
                string filename = "APIRequestJson_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
                StreamWriter sw = new StreamWriter(filepath + filename);

                sw.WriteLine(LogInput);

                sw.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {

            }
        }
        public static void WriteErrorLog(string LogInput)
        {

            try
            {
                string path = System.IO.Directory.GetCurrentDirectory();
                string filepath = path + "\\wwwroot\\ErrorLog\\";
                string filename = "APIRequestJson_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
                StreamWriter sw = new StreamWriter(filepath + filename);

                sw.WriteLine(LogInput);

                sw.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {

            }
        }
    }
}
