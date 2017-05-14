using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWindow.MainWindow
{
    public enum MainWindowPresenterSignal
    {
        TextChanged // _any_ key pressed, needs to handle spacebar, error checking and other magic
        // on secound thought not really signals are they

    }
    public class MainWindowPresenter
    {
        public MainWindowPresenter(MainWindowView view)
        {
            m_view = view;
            m_model = new Analysis.Analyst();
        }

        public void notify(MainWindowPresenterSignal signal)
        {
            switch (signal)
            {
                case MainWindowPresenterSignal.TextChanged:
                    handleTextChangedEvent();
                    break;
                default:
                    break;
            }
        }

        private void handleTextChangedEvent()
        {
            // TODO refactor into Analysis
            // get word
            m_model.RecordKeypress();
            string currentWord = m_view.gimmeUserInput();
            Console.WriteLine(currentWord);
            // run analysis magic
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
            m_view.setParagraphText(text);
            // start timer for paragraph and word
            m_model.StartParagraphTimer();
            m_model.StartWordTimer();
        }

        private void WordSuccess(string currentWord)
        {
            // stop current word timer
            m_view.highlightCorrect();
            if (m_model.IsFinished(currentWord))
            {
                m_model.StopWordTimer();
                m_view.setHighlightedWord(m_model.getNextWordLocation());
            }

        }

        private void WordFailure(string currentWord)
        {
            m_model.RecordError();
            m_view.highlightError();
        }

        private MainWindowView m_view;
        private MainWindowModel m_model;
    }
}
