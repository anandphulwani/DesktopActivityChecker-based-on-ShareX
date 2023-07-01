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
        private Dictionary<int, Timer> timersDict = new Dictionary<int, Timer>();

        public void AddTimer(int key, Timer timer)
        {
            timersDict[key] = timer;
        }

        public Timer GetTimer(int key)
        {
            if (timersDict.TryGetValue(key, out Timer timer))
            {
                return timer;
            }
            return null;
        }

        public void RemoveTimer(int key)
        {
            timersDict.Remove(key);
        }

        public void ReplaceKey(int oldKey, int newKey)
        {
            if (timersDict.TryGetValue(oldKey, out Timer timer))
            {
                timersDict.Remove(oldKey);
                timersDict[newKey] = timer;
            }
        }
    }
}