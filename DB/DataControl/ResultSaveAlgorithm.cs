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
        private DateTime LastTime = DateTime.Now;
        private DBControler DBcontrol = new DBControler();
        private SQLCommandExecuter tmp = new SQLCommandExecuter();
        public void ResultSave()
        {
            StringBuilder query = new StringBuilder();
            query.Clear();
            query.Append("SELECT TOP(1) ");
            query.Append("DATETIMEhh ");
            query.Append("FROM HourlyData");
            query.Append(";");

            string command = query.ToString();
            LastTimehh = tmp.SelectReturn(command);

            DateTime now = DateTime.Now;
            //if ()
            //{
            //    FunctionChooser = 1;
            //}
            //else if ()
            //{
            //    FunctionChooser = 2;
            //}
            //else
            //{
            //    FunctionChooser = 3;
            //}

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
        }
    }
}