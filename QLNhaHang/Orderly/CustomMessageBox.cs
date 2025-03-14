using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Orderly
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox(string message, string title = "Thông Báo")
        {
            InitializeComponent();

           
        }

        public static void ShowMessage(string message, string title = "Thông Báo")
        {
            CustomMessageBox msgBox = new CustomMessageBox(message, title);
            msgBox.ShowDialog();
        }
    }
}
