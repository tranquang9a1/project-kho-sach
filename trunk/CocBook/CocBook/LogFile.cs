using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CocBook
{
    public class LogFile
    {
        private string fileName;
        public LogFile()
        {
            fileName = "logfile.txt";
        }
        public LogFile(string fileName)
        {
            this.fileName = fileName;
        }
        ////Use LogFile to document the test run results
        /// <summary>
        /// The MyLogFile method is used to document details of each test run.
        /// </summary>
        public void MyLogFile(string strDateTime, string strMessage)
        {
            // Store the script names and test results in a output text file.
            using (StreamWriter writer = new StreamWriter(new FileStream(fileName, FileMode.Append)))
            {
                writer.WriteLine("{0}{1}", strDateTime, strMessage);
            }
        }
    }
}
