using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWindow.MainWindow
{
    class MainWindowModel
    {

        public void registerError()
        {
            m_errors++;
        }

        private string m_paragraph;
        private int m_currentWordStart;
        private int m_currentWordEnd;
        private int m_errors;
    }
}
