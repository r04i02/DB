using StrikeNeckDB.DataControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewStrikeNeckDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DBCreator tmp1 = new DBCreator();
            DBController tmp2 = new DBController();
            ResultSaveAlgorithm tmp3 = new ResultSaveAlgorithm();

            tmp1.CreateMinuteResultDB();
            tmp1.CreateHourResultDB();
            tmp1.CreateDayResultDB();

            tmp3.ResultSave(true);

            tmp2.HourResultSave();
            
            while (true)
            {
                DateTime date1 = DateTime.Now;
                //Console.WriteLine(date1.Second);
                Thread.Sleep(1000);
            }
        }
    }
}