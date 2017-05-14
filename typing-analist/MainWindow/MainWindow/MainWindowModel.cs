using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWindow.MainWindow
{
    class MainWindowModel
    {
        public Tuple<int, int> getNextWordLocation()
        {
            // make a list with the location of _all_ spaces in the paragraph
            // on each call just pop the first member, set that as end, and set the 
            // previous end as start
        }
        public bool isFinished(string word)
        {
            // check if last char is whitespace, if not return false
            // else check return (string[:-1] == the_correct_word)
        }
        public bool analysis(string word)
        {
            return true;
        }

        public void recordError()
        {
            m_errors++;
        }

        public void startWordTimer()
        {

        }
        public void stopWordTimer()
        {

        }

        public void startParagraphTimer()
        {

        }
        public void stopParagraphTimer()
        {

        }

        public void recordKeypress()
        {
            throw new NotImplementedException();
        }

        private string m_paragraph;
        private string m_currentWord;
        private int m_currentWordStart = 0;



        private int m_currentWordEnd;
        private int m_errors;
    }
}
