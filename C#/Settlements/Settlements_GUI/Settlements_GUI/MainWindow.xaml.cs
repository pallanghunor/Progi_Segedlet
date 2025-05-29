using Microsoft.EntityFrameworkCore;
using Settlements_GUI.Models;
using System.Collections.ObjectModel;
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

namespace Settlements_GUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private AppContext context;

    public ObservableCollection<Settlement> Settlements { get; set; }
    public ObservableCollection<County> County { get; set; }

    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = this;
        context = AppContext.GetContext();
        context.Settlement.Load();
        context.County.Load();
        Settlements = context.Settlement.Local.ToObservableCollection();
        County = context.County.Local.ToObservableCollection();
    }

    private void new_BTN_Click(object sender, RoutedEventArgs e)
    {
        DataWindow dataWindow = new DataWindow();
        dataWindow.ShowDialog();
        if(dataWindow.DialogResult == true)
        {
            Settlements.Add(dataWindow.NewSettlement);
            context.SaveChanges();
        }
    }
}