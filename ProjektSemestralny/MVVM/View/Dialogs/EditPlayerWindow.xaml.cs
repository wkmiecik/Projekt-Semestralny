using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjektSemestralny.MVVM.View.Dialogs
{
    /// <summary>
    /// Interaction logic for EditPlayerWindow.xaml
    /// </summary>
    public partial class EditPlayerWindow : Window
    {
        public EditPlayerWindow(string question, string defaultAnswer = "", string iconSource = "/Images/edit_icon.png")
        {
            InitializeComponent();
            lblQuestion.Content = question;
            txtAnswer.Text = defaultAnswer;
            icon.Source = new BitmapImage(new Uri(iconSource, UriKind.Relative));
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            txtAnswer.SelectAll();
            txtAnswer.Focus();
        }

        public string Answer
        {
            get { return txtAnswer.Text; }
        }
    }
}
