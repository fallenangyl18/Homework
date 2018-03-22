using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace sdev460
{
    public class Log
    {
       String path = ConfigurationManager.AppSettings["DirLoc"];

        StringBuilder sbLog = new StringBuilder();   // log file

        public StringBuilder SbLog { get => sbLog; set => sbLog = value; }
        public string Path { get => path; set => path = value; }

        public void writeToLog()
        {
            

            using (StreamWriter thisLog = File.AppendText(Path + "sdev460log.txt"))
            {
                thisLog.Write(SbLog);
                thisLog.Flush();
                thisLog.Close();
            }
           
        }
    }
}
