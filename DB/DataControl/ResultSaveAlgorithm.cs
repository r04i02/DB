using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DB.DataControl;

namespace StrikeNeckDB.DataControl
{
    internal class ResultSaveAlgorithm
    {
        private int FunctionChooser = 0;
        private int? LastTimehh;
        private int? LastTimedd;
        private DateTime now = DateTime.Now;
        private DBController DBcontrol = new DBController();
        private SQLCommandExecuter tmp = new SQLCommandExecuter();
        public void ResultSave(bool result)
        {
            StringBuilder query = new StringBuilder();
            query.Clear();
            query.Append("SELECT TOP 1 DATETIMEhh FROM HourlyData ORDER BY DATETIMEhh ASC;");

            string command = query.ToString();
            int? LastTimehh = tmp.SelectReturn(command);

            if (LastTimehh == null)
            {
                LastTimehh = -1;
            }

            query.Clear();
            query.Append("SELECT TOP 1 DATETIMEdd FROM YearlyData ORDER BY DATETIMEdd ASC;");

            string command1 = query.ToString();
            int? LastTimedd = tmp.SelectReturn(command1);

            if (LastTimedd == null)
            {
                LastTimedd = -1;
            }





            DateTime now = DateTime.Now;
            if (LastTimehh == -1)
            {
                FunctionChooser = 1;
            }
            else if (LastTimehh < now.Hour||(LastTimehh==23&&now.Hour==0))
            {
                FunctionChooser = 2;
            }
            else if (LastTimedd < now.Day && LastTimedd != 0 || (LastTimedd == 28 && now.Day == 1) || (LastTimedd == 29 && now.Day == 1) || (LastTimedd == 30 && now.Day == 1) || (LastTimedd == 31 && now.Day == 1))
            {
                FunctionChooser = 3;
            }

            if (FunctionChooser == 1)
            {
                DBcontrol.MinuteResultSave(result);
            }
            else if (FunctionChooser == 2)
            {
                DBcontrol.HourResultSave();
                DBcontrol.MinuteResultReset();
            }
            else if (FunctionChooser == 3)
            {
                DBcontrol.DayResultSave();
                DBcontrol.MinuteResultReset();
            }
        }
    }
}