using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analysis
{
    class Analyst : IAnalyst
    {

        private string m_paragraph;
        private string m_currentWord;
        private int m_currentWordStart = 0;



        private int m_currentWordEnd;
        private int m_errors;
    }
}
