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
        }

        public string gimmeUserInput()
        {
            return textBox1.Text;
        }

        public void setParagraphText(string text)
        {
            textBox1.Text = text;
        }

        public void setHighlightedWorld(int startPos, int endPos)
        {
            // TODO magic from http://stackoverflow.com/questions/11311/formatting-text-in-winform-label
            throw new NotImplementedException();
        }

        public void highlightInputInRed()
        {
            // TODO
            throw new NotImplementedException();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            m_presenter.notify(MainWindowPresenterSignal.TextChanged);
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private MainWindowPresenter m_presenter;
    }
}
