using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

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
            var par = "An ancient priestess regards you for a moment with weary eyes. \"Once we were many... Now, the servants of Amin have been defeated and the shadow of the Apep looms upon us.";
            string input = this.ShowDialog(par, "Text");

            m_presenter = new MainWindowPresenter(this, input);

            this.Activate();
            textBox1.Focus();
        }
        string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Width = 400, Text = text };
            FlowLayoutPanel flow = new FlowLayoutPanel() { Left = 50, Top = 50, Width = 400 };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            // this is dumb.. Refactor!
            if(prompt.ShowDialog() == DialogResult.OK){
                if(textBox.Text != "")
                {
                   return textBox.Text.Trim().Normalize();
                }
            }
            return textLabel.Text.Trim().Normalize();
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
            //m_presenter.notify(MainWindowPresenterSignal.KeyPressed);
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
