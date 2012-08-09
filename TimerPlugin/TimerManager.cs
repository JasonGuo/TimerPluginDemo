using System.Collections.Generic;
using System.Linq;

namespace TimerPlugin
{
    /// <summary>
    /// Code By:JasonGuo
    /// Date: 2012-7-24
    /// Blog: http://www.cnblogs.com/cheersun/ 
    /// </summary> 
    public sealed class TimerManager
    { 
        //维护一个timer list
        private List<BaseTimer> timerList = new List<BaseTimer>();

        //Singleton，只能维护一个Manager
        public static readonly TimerManager Instance = new TimerManager();
        private TimerManager() { }
          
        //注册单个BaseTimer
        public void RegiserTimer(BaseTimer baseTimer)
        {
            timerList.Add(baseTimer);
        }

        //启动所有Timers
        public void RunAllTimers()
        {
            if (timerList.Count() != 0)
            {
                foreach (BaseTimer timer in timerList)
                {
                    timer.TimerCase.Start();
                }
            }
        }

        //停止所有Timers
        public void StopAllTimers()
        {
            if (timerList.Count() != 0)
            {
                foreach (BaseTimer timer in timerList)
                {
                    timer.TimerCase.Stop();
                    timer.TimerCase.Close();
                }
            }
        }

        //根据TimerName停止单个Timer
        public void StopOneTimer(string timerName)
        {
            if (timerList.Count() != 0)
            {
                foreach (BaseTimer timer in timerList)
                {
                    if (timer.TimerName == timerName)
                    {
                        timer.TimerCase.Stop();
                        timer.TimerCase.Close();
                        break;
                    }
                }
            }
        }
        //获取所有Timer状态信息
        public List<TimerStatus> GetStatus()
        {
            List<TimerStatus> statusList = new List<TimerStatus>();
            if (timerList.Count() != 0)
            {
                foreach (BaseTimer timer in timerList)
                {
                    statusList.Add(new TimerStatus() { TimerName = timer.TimerName, Enabled = timer.TimerCase.Enabled });
                }
            }

            return statusList;
        }

        //根据TimerName启动单个Timer
        public void StartOneTimer(string timerName)
        {
            if (timerList.Count() != 0)
            {
                foreach (BaseTimer timer in timerList)
                {
                    if (timer.TimerName == timerName)
                    {
                        timer.TimerCase.Start();
                        break;
                    }
                }
            }
        }
    }
}
