using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Analysis
{
    // make the list of chars, or templated with default = char
    internal class KeyRecorder<T> : TimeRecorder
    {
        private List<T> m_keys;

        public KeyRecorder()
        {
            m_keys = new List<T>();
        }

        public new Tuple<List<long>, List<T>> Records
        {
            get
            {
                return new Tuple<List<long>, List<T>>(m_records, m_keys);
            }
        }
        public void AddNow(T key)
        {
            // add time from base class
            AddNow();
            // add key
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
