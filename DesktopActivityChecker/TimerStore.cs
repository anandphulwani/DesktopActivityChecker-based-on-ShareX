using System;
using System.Collections.Generic;
using System.Threading;

namespace DesktopActivityChecker
{
    public class TimerStore
    {
        private Dictionary<int, Tuple<Timer, FormData>> timersDict = new Dictionary<int, Tuple<Timer, FormData>>();
        private readonly object dictLock = new object();
        public void AddTimer(int key, Timer timer, FormData formData)
        {
            lock (dictLock)
            {
                timersDict[key] = new Tuple<Timer, FormData>(timer, formData);
            }
        }
        public Tuple<Timer, FormData> GetTimerData(int key)
        {
            lock (dictLock)
            {
                if (timersDict.TryGetValue(key, out Tuple<Timer, FormData> timerAndFormData))
                {
                    return timerAndFormData;
                }
                return null;
            }
        }
        public void RemoveTimer(int key)
        {
            lock (dictLock)
            {
                if (timersDict.TryGetValue(key, out Tuple<Timer, FormData> timerAndFormData))
                {
                    if (timerAndFormData.Item1 != null)
                    {
                        timerAndFormData.Item1.Dispose();
                    }
                }
                timersDict.Remove(key);
            }
        }
        public void ReplaceKey(int oldKey, int newKey)
        {
            lock (dictLock)
            {
                if (timersDict.TryGetValue(oldKey, out Tuple<Timer, FormData> timerAndFormData))
                {
                    FormData formData = timerAndFormData.Item2;
                    formData.Id = newKey;
                    timersDict.Remove(oldKey);
                    timersDict[newKey] = timerAndFormData;
                }
            }
        }
    }
}
