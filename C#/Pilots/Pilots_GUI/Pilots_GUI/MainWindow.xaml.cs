using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Pilots_GUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private ObservableCollection<Pilot> _pilots;

    public ObservableCollection<Pilot> Pilots
    {
        get { return _pilots; }
        set { _pilots = value; OnPropertyChanged("Pilots"); }
    }

    private readonly DataContext context;

    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = this;
        this.context = Pilots_GUI.DataContext.GetContext();
        context.Pilots.Load();
        Pilots = context.Pilots.Local.ToObservableCollection();
    }



    public bool InputCheck()
    {
        if (String.IsNullOrWhiteSpace(TBX_name.Text))
        {
            MessageBox.Show("A név mező kitöltése kötelező!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        if (CBX_gender.SelectedIndex == -1)
        {
            MessageBox.Show("Kérem válasszon nemet!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        if (DP_birthdate.SelectedDate is null)
        {
            MessageBox.Show("Kérem válasszon dátumot!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        if (DP_birthdate.SelectedDate > DateTime.Now)
        {
            MessageBox.Show("A választott dátum nem lehet nagyobb a mainál!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        if (String.IsNullOrWhiteSpace(TBX_nation.Text))
        {
            MessageBox.Show("A nemzetiség mező kitöltése kötelező!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        return true;
    }

    private void BTN_save_Click(object sender, RoutedEventArgs e)
    {
        if (InputCheck())
        {
            Pilot newPilot = new()
            {
                Name = TBX_name.Text,
                Gender = ((ComboBoxItem)CBX_gender.SelectedItem).Name,
                Birthdate = DP_birthdate.SelectedDate,
                Nation = TBX_nation.Text,
            };
            context.Pilots.Add(newPilot);
            context.SaveChanges();
            TBX_name.Text = "";
            CBX_gender.SelectedIndex = -1;
            DP_birthdate.SelectedDate = null;
            TBX_nation.Text = "";
        }
    }

    private void BTN_del_Click(object sender, RoutedEventArgs e)
    {
        if (DG_data.SelectedItem is not null)
        {
            MessageBoxResult confirmation = MessageBox.Show(
                    $"Biztosan kívánja törölni a(z) {((Pilot)DG_data.SelectedItem).Name} nevű pilótát?",
                    "Megerősítés",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
            if (confirmation == MessageBoxResult.Yes)
            {
                context.Pilots.Remove((Pilot)DG_data.SelectedItem);
                context.SaveChanges();
            }

        }
    }
}
