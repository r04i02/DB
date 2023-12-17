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
        private DateTime now = DateTime.Now;
        private SQLCommandExecuter tmp = new SQLCommandExecuter();
        public void MinuteResultSave(bool result)
        {
            StringBuilder query = new StringBuilder();
            query.Clear();
            query.Append("INSERT INTO HourlyData VALUES(");
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
            tmp.ExecuteNonQuery(query.ToString());

            query.Clear();
        }

        public void HourResultSave()    //引数が本来は必要なはず…なのでそれを追加
        {

        }

        public void DayResultSave()     //引数が本来は必要なはず…なので以下略
        {

        }

        public void MinuteResultReset()
        {

        }
    }
}