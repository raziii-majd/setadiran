using SetadIran.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetadIran.Service
{
    internal class LoggingService
    {
        static public void Log(string logMessage, string controller, string api, bool iserror, string title, string exception, string type)
        {
            Console.WriteLine(DateTime.Now.ToString() + " : " + logMessage);
            try
            {
                using (MainContext _db = new MainContext())
                {
                    _db.Dlogs.Add(new Model.DebugLog
                    {
                        API = api,
                        Appliocation = "DataGatherer",
                        Controller = controller,
                        Exception = exception,
                        Title = title,
                        Message = logMessage,
                        IsError = iserror,
                        ServerDateTime = DateTime.Now,
                        Type = type
                    });
                    _db.SaveChanges();
                }
            }
            catch { }
        }
    }
}
