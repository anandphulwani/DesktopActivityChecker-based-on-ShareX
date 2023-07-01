using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopActivityChecker
{
    public class TimerStore
    {
        private Dictionary<string, Timer> timersDict = new Dictionary<string, Timer>();

        public void AddTimer(string key, Timer timer)
        {
            timersDict[key] = timer;
        }

        public Timer GetTimer(string key)
        {
            if (timersDict.TryGetValue(key, out Timer timer))
            {
                return timer;
            }
            return null;
        }

        public void RemoveTimer(string key)
        {
            timersDict.Remove(key);
        }
        // Other methods as needed...
    }
}