using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DB.DataControl;

namespace StrikeNeckDB.DataControl
{
    internal class DBController
    {
        private int UptimeMinute = 0;
        private DateTime now = DateTime.Now;
        private DBCreator DBCreateObject = new DBCreator();
        private SQLCommandExecuter SQLcommandEcecuteObject = new SQLCommandExecuter();
        public void MinuteResultSave(bool result)
        {
            StringBuilder query = new StringBuilder();
            query.Clear();
            query.Append("SELECT TOP 1 UptimeMinute FROM HourlyData ORDER BY UptimeMinute ASC;");

            string command = query.ToString();
            int? UptimeMinute = SQLcommandEcecuteObject.ReturnResult(command);
            if(UptimeMinute==null)
            {
                UptimeMinute = 0;
                Console.WriteLine("null");
            }

            UptimeMinute += 1;

            //Console.WriteLine(UptimeMinute);

            query.Clear();
            query.Append("INSERT INTO HourlyData VALUES(");
            query.Append(UptimeMinute);
            query.Append(",");
            query.Append(now.Hour);
            if (result)
            {
                query.Append(",1");
            }
            else
            {
                query.Append(",0");
            }
            query.Append(");");
            //SQLcommandEcecuteObject.ExecuteNonQuery(query.ToString());

            query.Clear();
        }

        public void HourResultSave()    //引数が本来は必要なはず…なのでそれを追加
        {
            StringBuilder query = new StringBuilder();

            query.Clear();
            query.Append("SELECT COUNT(*)");
            query.Append("FROM HourlyData;");
            UptimeMinute = SQLcommandEcecuteObject.ReturnResult(query.ToString());

            Console.WriteLine(UptimeMinute);

            query.Clear();
        }

        public void DayResultSave()     //引数が本来は必要なはず…なので以下略
        {

        }

        public void MinuteResultReset()
        {
            //DropTableを作る
            DBCreateObject.CreateMinuteResultDB();
        }
    }
}