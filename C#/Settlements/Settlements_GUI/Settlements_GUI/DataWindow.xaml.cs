using Settlements_GUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Settlements_GUI
{
    /// <summary>
    /// Interaction logic for DataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
        private AppContext context;
        public Settlement NewSettlement { get; set; }
        public ObservableCollection<County> Counties { get; set; }
        public DataWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            context = AppContext.GetContext();
            NewSettlement = new Settlement();
            Counties = context.County.Local.ToObservableCollection();
        }

        private void save_BTN_Click(object sender, RoutedEventArgs e)
        {
            if (InputCheck())
            {
                this.DialogResult = true;
                this.Close();
            }
        }

        private bool InputCheck()
        {
            if (String.IsNullOrWhiteSpace(NewSettlement.Name))
            {
                MessageBox.Show("A név megadása kötelező!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if(NewSettlement.County == null)
            {
                MessageBox.Show("A megye megadása kötelező!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (String.IsNullOrWhiteSpace(NewSettlement.Region))
            {
                MessageBox.Show("A régió megadása kötelező!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if(NewSettlement.Population == null || NewSettlement.Population < 1)
            {
                MessageBox.Show("A lakkoság számának megadása kötelező és 0-nál nagyobb szám kell legyen!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (NewSettlement.Areasize == null || NewSettlement.Areasize < 1)
            {
                MessageBox.Show("A terület  méretének megadása kötelező és 0-nál nagyobb szám kell legyen!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }


    }
}
