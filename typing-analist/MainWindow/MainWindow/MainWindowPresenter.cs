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
            m_model = new MainWindowModel();
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
            // get word
            m_model.recordKeypress();
            string currentWord = m_view.gimmeUserInput();
            Console.WriteLine(currentWord);
            // run analysis magic
            if (m_model.analysis(currentWord))
            {
                m_view.highlightCorrect();
                if (m_model.isFinished(currentWord))
                {
                    m_model.stopWordTimer();
                    m_view.setHighlightedWord(m_model.getNextWordLocation());
                }
            }
            else
            {
                m_view.highlightError();
                m_model.recordError();
            }
            // check if equals current word
            // on WordSuccess, // highlight the next word
            // on WordFailure // highlight current word with red, or actually the *field*?
        }

        private void setParagraphText(string text)
        {
            m_view.setParagraphText(text);
            // start timer for paragraph and word
            m_model.startParagraphTimer();
            m_model.startWordTimer();
        }

        private void WordSuccess()
        {
            // stop current word timer
            m_model.stopWordTimer();

        }

        private void WordFailure()
        {
            m_model.recordError();
            m_view.highlightError();
        }

        private MainWindowView m_view;
        private MainWindowModel m_model;
    }
}
