using System;
using System.IO;

namespace LearnMVC.Logger
{
    public class FileLogger
    {
        public void LogException(Exception e)
        {
            File.WriteAllLines("C://Users//gkj//Documents//Visual Studio 2013//Projects//LearnMVC//Logfiles//LearnMVC Error " + DateTime.Now.ToString("yyyy-MM-dd mm hh ss") + ".txt",
            new string[]{
                "Message: "+ e.Message,
                "Stacktrace: "+ e.StackTrace
            });
        }
    }
}