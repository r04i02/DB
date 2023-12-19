using System;
using Microsoft.Data.Sqlite;
using System.Configuration;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using DB.DataControl;

namespace StrikeNeckDB.DataControl
{
    public class DBCreator
    {
        private DateTime now = DateTime.Now;
        SQLCommandExecuter SQLcommandEcecuteObject = new SQLCommandExecuter();
        public void CreateMinuteResultDB()
        {
            StringBuilder query = new StringBuilder();
            query.Clear();
            query.Append("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'HourlyData') ");
            query.Append("CREATE TABLE HourlyData(");
            query.Append("UptimeMinute INTEGER NOT NULL");
            query.Append(",DATETIMEhh INTEGER NOT NULL");
            query.Append(",ForwardLeanMinute INTEGER NOT NULL");
            query.Append(",primary key(DATETIMEhh)");
            query.Append(");");

            SQLcommandEcecuteObject.ExecuteNonQuery(query.ToString());

            query.Clear();
        }


        public void CreateHourResultDB()
        {
            StringBuilder query = new StringBuilder();
            query.Clear();
            query.Append("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'DailyData') ");
            query.Append("CREATE TABLE DailyData(");
            query.Append("DATETIMEdd INTEGER NOT NULL");
            query.Append(",DATETIMEhh INTEGER NOT NULL");
            query.Append(",UptimeHour INTEGER NOT NULL");
            query.Append(",ForwardLeanMinute INTEGER NOT NULL");
            query.Append(",primary key(DATETIMEhh)");
            query.Append(");");

            SQLcommandEcecuteObject.ExecuteNonQuery(query.ToString());
        }

        public void CreateDayResultDB()
        {
            StringBuilder query = new StringBuilder();
            query.Clear();
            query.Append("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'YearlyData') ");
            query.Append("CREATE TABLE YearlyData(");
            query.Append("DATETIMEdd INTEGER NOT NULL");
            query.Append(",UptimeHour INTEGER NOT NULL");
            query.Append(",ForwardLeanHour INTEGER NOT NULL");
            query.Append(",primary key(DATETIMEdd)");
            query.Append(");");

            SQLcommandEcecuteObject.ExecuteNonQuery(query.ToString());
        }
    }
}