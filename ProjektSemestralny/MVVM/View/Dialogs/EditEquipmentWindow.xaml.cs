using ProjektSemestralny.MVVM.Model;
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
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace ProjektSemestralny.MVVM.View.Dialogs
{
    /// <summary>
    /// Interaction logic for EditEquipmentWindow.xaml
    /// </summary>
    public partial class EditEquipmentWindow : Window
    {
        public EditEquipmentWindow(ObservableCollection<equipment> equipmentList, equipment defaultEq, bool enabled = true, int defaultQuantity = 0, string iconSource = "/Images/edit_icon.png")
        {
            InitializeComponent();
            
            equipmentComboBox.ItemsSource = equipmentList;
            equipmentComboBox.SelectedValue = defaultEq;
            equipmentComboBox.IsEnabled = enabled;
            quantityTextBox.Text = defaultQuantity.ToString();

            icon.Source = new BitmapImage(new Uri(iconSource, UriKind.Relative));
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            quantityTextBox.SelectAll();
            quantityTextBox.Focus();
        }

        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public int QuantityAnswer
        {
            get { return int.Parse(quantityTextBox.Text); }
        }

        public equipment EquipmentAnswer
        {
            get { return (equipment)equipmentComboBox.SelectedItem; }
        }
    }
}
