using System;
using System.Collections.Generic;

namespace Analysis
{
    using KeypressStorageType = String;
    using WordStorageType = String;

    public class Analyst
    {
        // The words must end with spaces, this is done to avoid a concatenation on checking
        // Except the last one!
        private List<string> m_paragraph;
        private int m_currentWord = 0;

        public string Paragraph()
        {
            return String.Join("", m_paragraph.ToArray());
        }

        public string CurrentWord
        {
            get
            {
                return m_paragraph[m_currentWord];
            }
        }
        private int m_wordStartOffset = 0;

        private int m_wordEnd = 0;

        private int m_errors;
        private Type m_keyRecorderType = typeof(char);
        private DataRecorder<KeypressStorageType> m_keypresses;
        private DataRecorder<WordStorageType> m_wordTimer;
        private TimeRecorder m_paragraphTimer;

        public Analyst(List<string> paragraph = null)
        {
            if (paragraph == null)
            {
                //var par = "A number of types support format strings, including all numeric types";
                var par = "Linq equivalents of Map and Reduce: If you're lucky enough to have linq.";
                m_paragraph = new List<string>(par.Split(' '));

                // add a space on all except the last one
                for (int i = 0; i < m_paragraph.Count - 1; ++i)
                {
                    m_paragraph[i] += ' ';
                }
            }
            else
            {
                m_paragraph = paragraph;
            }

            m_keypresses = new DataRecorder<KeypressStorageType>();
            m_wordTimer = new DataRecorder<WordStorageType>();
            m_paragraphTimer = new TimeRecorder();
            m_wordEnd = CurrentWord.Length - 1;
        }

        public bool IsLastWord()
        {
            return m_currentWord == m_paragraph.Count - 1;
        }
        public int CharactersPerMinute()
        {
            throw new NotImplementedException();
        }
        public int WordsPerMinute()
        {
            throw new NotImplementedException();
        }
        public bool Correct(string word)
        {
            return CurrentWord.Contains(word);
        }
        public void RecordError()
        {
            m_errors++;
        }

        public bool IsFinished(string word)
        {
            // check if last char is whitespace, if not return false
            // else check return (string[:-1] == the_correct_word)
            return CurrentWord == word;
        }

        public void MoveToNextWord()
        {
            // We don't do +1 because that crops out the space at the end of each word in the list
            m_wordStartOffset += CurrentWord.Length;
            ++m_currentWord;
            m_wordEnd = CurrentWord.Length - 1;
        }

        public Tuple<int, int> WordLocation()
        {
            // make a list with the location of _all_ spaces in the paragraph
            // on each call just pop the first member, set that as end, and set the 
            // previous end as start

            return new Tuple<int, int>(m_wordStartOffset, m_wordEnd);
        }
        public void RecordError(string partial_word)
        {
            throw new NotImplementedException();
        }

        public void RecordKeypress(string key)
        {
            m_keypresses.AddNow(key);
        }

        public void StartParagraphTimer()
        {
            // We're gonna be ignoring the first occurence in the list
            m_wordTimer.AddNow();
        }
        public void StopParagraphTimer()
        {
            m_paragraphTimer.AddNow();
        }

        public void StartWordTimer()
        {
            // We're gonna be ignoring the first occurence in the list
            m_wordTimer.AddNow();
        }

        public void StopWordTimer(string currentWord)
        {
            Console.WriteLine("Word being added: " + currentWord);
            m_wordTimer.AddNow(currentWord);
        }

        public Tuple<List<long>, List<KeypressStorageType>> KeypressTimes()
        {
            return m_keypresses.Records;
        }
        public Tuple<List<long>, List<WordStorageType>> WordTimes()
        {
            return m_wordTimer.Records;
        }
        public List<long> ParagraphTime()
        {
            return m_paragraphTimer.Records;
        }

    }
}
