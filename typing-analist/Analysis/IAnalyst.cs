using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Analysis
{
    interface IAnalyst
    {
        void StartParagraphTimer();
        void EndParagraphTimer();

        void StartWordTimer();
        void EndWordTimer();
        bool Correct(string word);

        Time.Time ElapsedTimeForWord();
        Time.Time ElapsedTimeForParagraph();

        // this will internally store the time it took for a key to be pressed
        // can be calculated by CurrentTime() - LastCallTime()
        void RecordKeypress(char key);

        // will be calculated by the average speed for multiple words
        // or the CharactersPerMinute / <5 character per average word>
        int WordsPerMinute();

        // will be the number of registered keypresser in the range of a minute
        int CharactersPerMinute();

        void RecordError();

        // registers an error and also stores the partial word for further analysis
        void RecordError(string partial_word);

        bool IsFinished(string partial_word);

        Tuple<int, int> NextWordLocation();
    }
}
