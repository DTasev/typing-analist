using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Analysis
{
    internal class KeyRecorder : TimeRecorder
    {
        private List<string> m_keys;

        public KeyRecorder()
        {
            m_keys = new List<string>();
        }

        public new Tuple<List<long>, List<string>> Records
        {
            get
            {
                return new Tuple<List<long>, List<string>>(m_records, m_keys);
            }
        }
        public void AddNow(string key)
        {
            AddNow();
            m_keys.Add(key);
        }
    }
    internal class TimeRecorder
    {
        protected List<long> m_records;
        protected Stopwatch m_timer;

        public TimeRecorder()
        {
            m_timer = new Stopwatch();
            m_records = new List<long>();
            m_timer.Start();
        }

        public List<long> Records
        {
            get
            {
                return m_records;
            }
        }
        public void AddNow()
        {
            m_records.Add(m_timer.ElapsedMilliseconds);
        }

        public void Stop()
        {
            m_timer.Stop();
        }
    }
}
