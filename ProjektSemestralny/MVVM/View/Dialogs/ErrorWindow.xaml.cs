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
    /// Interaction logic for ErrorWindow.xaml
    /// </summary>
    public partial class ErrorWindow : Window
    {
        public ErrorWindow(string text)
        {
            InitializeComponent();

            Textbar.Text = text;
            
            okBtn.Focus();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.MouseDown += delegate { DragMove(); };
        }
    }
}
