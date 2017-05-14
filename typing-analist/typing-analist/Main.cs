using System;
using System.Collections.Generic;
using System.Windows.Forms;

using MainWindow.MainWindow;

namespace typing_analist
{
    class Program
    {
        static List<string> convertFromString(string inputString)
        {
            return new List<string>(inputString.Split(' '));
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindowView());
        }
    }
}
