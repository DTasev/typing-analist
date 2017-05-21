using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWindow.MainWindow
{
    public enum MainWindowPresenterSignal
    {
        TextChanged,
        KeyPressed
    }

    public class MainWindowPresenter
    {
        const int AVERAGE_WORD_LENGTH = 6;

        public MainWindowPresenter(MainWindowView view)
        {
            m_view = view;
            m_model = new Analysis.Analyst();
            m_view.SetParagraphText(m_model.Paragraph());
            m_view.HighlightWord(m_model.WordLocation(), WordColor.GOOD);
        }

        public void notify(MainWindowPresenterSignal signal)
        {
            switch (signal)
            {
                case MainWindowPresenterSignal.TextChanged:
                    handleTextChangedEvent();
                    break;
                case MainWindowPresenterSignal.KeyPressed:
                    handleKeyPressedEvent();
                    break;
                default:
                    break;
            }
        }

        private void handleKeyPressedEvent()
        {
            m_model.RecordKeypress(m_view.LastKey);
        }

        private void handleTextChangedEvent()
        {
            // TODO refactor into Analysis get word
            string currentWord = m_view.GimmeUserInput();

            if (m_model.Correct(currentWord))
            {
                WordSuccess(currentWord);
            }
            else
            {
                WordFailure(currentWord);
            }
            // check if equals current word
            // on WordSuccess, // highlight the next word
            // on WordFailure // highlight current word with red, or actually the *field*?
        }

        private void setParagraphText(string text)
        {
            m_view.SetParagraphText(text);
            // start timer for paragraph and word
            m_model.StartParagraphTimer();
            m_model.StartWordTimer();
        }

        private void WordSuccess(string currentWord)
        {
            // We need to redraw the link every time, if the user had a wrong input
            // before this will clear it
            m_view.HighlightWord(m_model.WordLocation(), WordColor.GOOD);
            // check if the user has typed in the whole word to move on
            if (m_model.IsFinished(currentWord))
            {
                m_model.StopWordTimer();
                if (m_model.IsLastWord())
                {
                    m_model.StopParagraphTimer();
                    Console.WriteLine("Average time per keypress in ms:");
                    // Subtract the first value as 'background'
                    var res = m_model.KeypressTimes();
                    var list = res.Item1;
                    var background = list[0];
                    list.Select(x => x - background);
                    
                    var data = new List<long>(list.Count - 1);

                    for(int i = 0; i < list.Count-1; ++i)
                    {
                        data.Add(list[i + 1] - list[i]);
                    }

                    var avg = data.Average();
                    Console.WriteLine(avg);
                    // see how many chars we can do in a full second (1000ms)
                    var cps = 1000 / avg;
                    Console.WriteLine("Chars per second:\n"+cps);
                    // how many chars we can do in a minute
                    var cpm = 60 * cps;
                    Console.WriteLine("Chars per minute:\n"+cpm);
                    // divide chars per minute to get the word length
                    var wpm_6 = cpm / AVERAGE_WORD_LENGTH;
                    var wpm_5 = cpm / 5;
                    var wpm_51 = cpm / 5.1;
                    Console.WriteLine(String.Format("Words per minute with arbitrary word length {0}:\n{1}", AVERAGE_WORD_LENGTH, wpm_6));
                    Console.WriteLine(String.Format("Words per minute with arbitrary word length {0}:\n{1}", 5, wpm_5));
                    Console.WriteLine(String.Format("Words per minute with arbitrary word length {0}:\n{1}", 5.1, wpm_51));
                    Console.WriteLine("All keypresses:");
                    for (int i = 0; i < res.Item1.Count; ++i)
                    {
                        Console.WriteLine("Time:" + (res.Item1[i] - res.Item1[0]) + " Key: " + res.Item2[i]);
                    }
                    Console.WriteLine("Average time per Word:");
                    Console.WriteLine(m_model.WordTimes().Average());
                    Console.WriteLine("Paragraph time:");
                    m_model.ParagraphTime().ForEach(Console.WriteLine);
                }
                else
                {
                    m_model.MoveToNextWord();
                    m_view.ClearUserInput();
                }
            }

        }

        private void WordFailure(string currentWord)
        {
            m_model.RecordError();
            // the word will not be moved
            m_view.HighlightWord(m_model.WordLocation(), WordColor.BAD);
        }

        private MainWindowView m_view;
        private Analysis.Analyst m_model;
    }
}
