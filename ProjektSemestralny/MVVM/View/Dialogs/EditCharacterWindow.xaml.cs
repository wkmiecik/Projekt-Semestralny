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
    public partial class EditCharacterWindow : Window
    {
        public EditCharacterWindow(string defaultName = "", string defaultLevel = "", string iconSource = "/Images/edit_icon.png")
        {
            InitializeComponent();
            name.Text = defaultName;
            level.Text = defaultLevel;
            icon.Source = new BitmapImage(new Uri(iconSource, UriKind.Relative));
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            name.SelectAll();
            name.Focus();
        }

        public string NameAnswer
        {
            get { return name.Text; }
        }
        public string LevelAnswer
        {
            get { return level.Text; }
        }
    }
}
