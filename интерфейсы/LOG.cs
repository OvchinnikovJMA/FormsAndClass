using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace интерфейсы
{
    class LOG
    {
        CurrentUserLog CurrentUserLog;
        readonly private string path = @"C:\Users\teesh\source\repos\интерфейсы\интерфейсы\Log.txt";
        public LOG(CurrentUserLog currentUserLog)
        {
            CurrentUserLog = currentUserLog;
        }

        public void DoLog(string buttonName)
        {
            if (!File.Exists(path))
                using (StreamWriter sw = File.CreateText(path))
                    sw.WriteLine("[" + DateTime.Now.ToString() + "]" + CurrentUserLog.currentLogin + ": " + buttonName);
            else
                using (StreamWriter sw = new StreamWriter(path, true))
                    sw.WriteLine("[" + DateTime.Now.ToString() + "]" + CurrentUserLog.currentLogin + ": " + buttonName);
        }
    }

    public class CurrentUserLog
    {
        public string currentLogin;
        public string currentPassword;
    }
}
