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
        private int LastTimehh = 0;
        private int LastTimedd = 0;
        private DateTime now = DateTime.Now;
        private DBController DBcontrol = new DBController();
        private SQLCommandExecuter tmp = new SQLCommandExecuter();
        public void ResultSave()
        {
            StringBuilder query = tmp.GetSelectReturnQuery("DATETIMEhh", "HourlyData");
            string command = query.ToString();
            LastTimehh = tmp.SelectReturn(command);

            query = tmp.GetSelectReturnQuery("DATETIMEdd", "YearlyData");
            command = query.ToString();
            LastTimedd = tmp.SelectReturn(command);

            DateTime now = DateTime.Now;
            if (LastTimehh == 0)
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
                DBcontrol.MinuteResultSave();
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
            Console.WriteLine(LastTimehh);
        }
    }
}