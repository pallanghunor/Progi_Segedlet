using Microsoft.EntityFrameworkCore;
using .Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 
{    
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // private SearchModel SearchValues { get; set; } = new();
        private ObservableCollection<> _;

        public ObservableCollection<> 
        {
            get { return _; }
            set { _ = value; OnPropertyChanged(""); }
        }
        
        private readonly DataContext context;

        public MainWindow()
        {
            InitializeComponent();
            this.context = .DataContext.GetContext();
            //context..Include(o => o.otherTableProp).Load();            
             = context..Local.ToObservableCollection();
        }               

        private void DG_data_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OrderDetailWindow detailWindow = new(this.SelectedOrder);
            detailWindow.ShowDialog();
        }
    }
}