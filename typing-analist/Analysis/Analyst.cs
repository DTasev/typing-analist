using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analysis.Time;

namespace Analysis
{
    public class Analyst : IAnalyst
    {

        private string m_paragraph;
        private string m_currentWord;
        private int m_currentWordStart = 0;

        private int m_currentWordEnd;
        private int m_errors;

        public int CharactersPerMinute()
        {
            throw new NotImplementedException();
        }

        public bool Correct(string word)
        {
            throw new NotImplementedException();
        }

        public Time.Time ElapsedTimeForParagraph()
        {
            throw new NotImplementedException();
        }

        public Time.Time ElapsedTimeForWord()
        {
            throw new NotImplementedException();
        }

        public void EndParagraphTimer()
        {
            throw new NotImplementedException();
        }

        public void EndWordTimer()
        {
            throw new NotImplementedException();
        }

        public bool IsFinished(string partial_word)
        {
            // check if last char is whitespace, if not return false
            // else check return (string[:-1] == the_correct_word)
        }

        public Tuple<int, int> NextWordLocation()
        {
            throw new NotImplementedException();
            // make a list with the location of _all_ spaces in the paragraph
            // on each call just pop the first member, set that as end, and set the 
            // previous end as start
        }

        public void RecordError()
        {
            m_errors++;
        }

        public void RecordError(string partial_word)
        {
            throw new NotImplementedException();
        }

        public void RecordKeypress(char key)
        {
            throw new NotImplementedException();
        }

        public void StartParagraphTimer()
        {
            throw new NotImplementedException();
        }

        public void StartWordTimer()
        {
            throw new NotImplementedException();
        }

        public int WordsPerMinute()
        {
            throw new NotImplementedException();
        }
    }
}
