using System;

using System.Timers;
namespace TimerPlugin
{
    /// <summary>
    /// Code By:JasonGuo
    /// Date: 2012-7-24
    /// Blog: http://www.cnblogs.com/cheersun/ 
    /// </summary>  
    public class BaseTimer
    {
        //定时器名称 
        public string TimerName { get; set; }
        //定时器
        public Timer TimerCase = new Timer();
        //异常委托  
        public delegate void ExceptionDelegate(Exception ex);
        public ExceptionDelegate RegExceptionMethod;
        //public static event Action<BaseTimer, Exception> RegExceptionMethod;

        public BaseTimer(string timerName, double interval)
        {
            TimerName = timerName;
            TimerCase.Interval = interval;
            TimerCase.Enabled = false;
            TimerCase.Elapsed += Run;
        }

        private void Run(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                this.Run();
            }
            catch (Exception ex)
            {
                //日志记录,重启服务 
                RegExceptionMethod(ex);
            }
        }

        public virtual void Run()
        {

        }
    }
}
