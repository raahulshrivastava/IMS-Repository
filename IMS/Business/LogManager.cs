using IMS.DataContext;
using IMS.Utilities;
using System;

namespace IMS.Business
{
    public class LogManager
    {
        public static void InsertIntoLogTable(Exception ex)
        {
           
            using (var db=new IMSContext())
            {
                LogTable log = new LogTable();
                log.Helpline = ex.HelpLink.ToString();
                log.Message = ex.Message.ToString();
                log.Source = ex.Source.ToString();
                log.UserId = 0;
                log.UserName = "";
                log.InnerException = ex.InnerException.ToString();
                log.StackTrace = ex.StackTrace.ToString();
                log.UserId = UserSession.Id;
                log.UserName = UserSession.UserName;
                db.LogTables.Add(log);
                db.SaveChanges();
            }
        }

      
    }
}