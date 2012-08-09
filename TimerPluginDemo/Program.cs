using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TimerPlugin;
namespace TimerPluginDemo
{

    class Program
    {
        public static void Main(string[] args)
        {
            TimerManager timerManager = TimerManager.Instance;

            //OrderTimerCase
            var orderTimerCase = new OrderTimerCase("OrderTimerCase", 3000);
            orderTimerCase.RegExceptionMethod += Program.LogException;
            timerManager.RegiserTimer(orderTimerCase);

            ////ProductTimerCase
            //var productTimerCase = new ProductTimerCase("ProductTimerCase", 4000);
            //productTimerCase.RegExceptionMethod += Program.LogException;
            //timerManager.RegiserTimer(productTimerCase);

            timerManager.RunAllTimers();
            Console.ReadLine();

            timerManager.StopOneTimer("ProductTimerCase");
            Console.ReadLine();

            Console.WriteLine("Timer运行状态");
            foreach (TimerStatus ts in timerManager.GetStatus())
            {
                Console.WriteLine(ts.TimerName + ":" + ts.Enabled);
            }
            Console.ReadLine();

            Console.WriteLine("重新启动ProductTimerCase");
            timerManager.StartOneTimer("ProductTimerCase");
            Console.ReadLine();

            Console.WriteLine("Timer运行状态");
            foreach (TimerStatus ts in timerManager.GetStatus())
            {
                Console.WriteLine(ts.TimerName + ":" + ts.Enabled);
            }
            Console.ReadLine();

            timerManager.StopAllTimers();
            Console.WriteLine("停止所有Timers");
            Console.ReadLine();
        }

        public static void LogException(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
