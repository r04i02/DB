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
            ResultSaveAlgorithm tmp2 = new ResultSaveAlgorithm();

            tmp1.MinuteResultSaveDBCreator();
            tmp1.HourResultSaveDBCreator();
            tmp1.DayResultSaveDBCreator();

            tmp2.ResultSave(true);

            
            while (true)
            {
                DateTime date1 = DateTime.Now;
                Console.WriteLine(date1.Second);
                Thread.Sleep(1000);
            }
        }
    }
}