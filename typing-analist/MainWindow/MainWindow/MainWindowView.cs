using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainWindow.MainWindow
{
    public partial class MainWindowView : Form
    {
        public MainWindowView()
        {
            InitializeComponent();
            m_presenter = new MainWindowPresenter(this);
            setHighlightedWord(0,4);
            highlightCorrect();
        }

        public string gimmeUserInput()
        {
            return textBox1.Text;
        }

        public void setParagraphText(string text)
        {
            textBox1.Text = text;
        }

        public void setHighlightedWord(Tuple<int, int> t)
        {
            // TODO magic from http://stackoverflow.com/questions/11311/formatting-text-in-winform-label
            linkLabel1.Links.Clear();

            linkLabel1.Links.Add(t.Item1, t.Item2);
            linkLabel1.LinkColor = Color.DarkBlue;
        }

        public void highlightCorrect()
        {
            textBox1.ForeColor = Color.Blue;
        }
        public void highlightError()
        {
            textBox1.ForeColor = Color.Red;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            m_presenter.notify(MainWindowPresenterSignal.TextChanged);
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Console.WriteLine("No Touchy");
        }

        private MainWindowPresenter m_presenter;
    }
}
