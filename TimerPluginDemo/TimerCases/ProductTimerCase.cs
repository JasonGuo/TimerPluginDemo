using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TimerPlugin;
namespace TimerPluginDemo
{
    public class ProductTimerCase : BaseTimer
    {
        public ProductTimerCase(string timerName, double interval)
            : base(timerName, interval)
        {

        }

        public override void Run()
        {
           // throw new Exception(int.Parse("测试").ToString());
            //throw new Exception("ProductTimerCase出错ing");
            //Console.WriteLine("{0} is running At {1}!", base.TimerName, DateTime.Now);
        }
    }
}
