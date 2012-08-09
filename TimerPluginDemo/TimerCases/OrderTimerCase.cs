using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TimerPlugin;
namespace TimerPluginDemo
{
    public class OrderTimerCase : BaseTimer
    {
        public OrderTimerCase(string timerName, double interval)
            : base(timerName, interval)
        {

        }

        public override void Run()
        {
            Console.WriteLine("{0} is running At {1}!", base.TimerName, DateTime.Now);
        }
    }
}
