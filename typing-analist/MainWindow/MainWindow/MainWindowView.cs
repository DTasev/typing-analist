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
    public enum WordColor
    {
        GOOD,
        BAD
    }

    public partial class MainWindowView : Form
    {
        public MainWindowView()
        {
            InitializeComponent();
            m_presenter = new MainWindowPresenter(this);
            this.Activate();
            textBox1.Focus();
        }

        public string GimmeUserInput()
        {
            return textBox1.Text;
        }

        public void SetParagraphText(string text)
        {
            linkLabel1.Text = text;
        }

        public void HighlightWord(Tuple<int, int> indices, WordColor color)
        {
            // magic from http://stackoverflow.com/questions/11311/formatting-text-in-winform-label
            linkLabel1.Links.Clear();

            // only colour in the current word!
            linkLabel1.Links.Add(indices.Item1, indices.Item2);
            if (color == WordColor.GOOD)
            {
                linkLabel1.LinkColor = Color.Green;
            }
            else
            {
                linkLabel1.LinkColor = Color.Red;

            }
        }

        public void ClearUserInput()
        {
            textBox1.Clear();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            m_lastKey = e.KeyCode;
            m_presenter.notify(MainWindowPresenterSignal.KeyPressed);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // This function is, for some reason, triggered before the presenter is initialised...
            // so we need to check if it's been initialised or not
            if (m_presenter == null)
            {
                return;
            }
            m_presenter.notify(MainWindowPresenterSignal.TextChanged);
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Console.WriteLine("No Touchy");
        }

        private MainWindowPresenter m_presenter;
        private Keys m_lastKey;
        public string LastKey
        {
            get{
                return m_lastKey.ToString();
            }
        }
    }
}
