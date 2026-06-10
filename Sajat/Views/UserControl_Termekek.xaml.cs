using Sajat.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sajat.Views
{
    /// <summary>
    /// Interaction logic for UserControl_Termekek.xaml
    /// </summary>
    public partial class UserControl_Termekek : UserControl
    {
        List<Termekek> felhasznalok;
        Termekek valasztottermek;
     
            
        public UserControl_Termekek()
        {
            InitializeComponent();
            felhasznalok = new List<Termekek>();
            ReadDB();

          

        }



        private void ReadDB()
        {
            
            teljesNevTextBox.Text = "";
            felhasznaloNevTextBox.Text = "";
            

            var Felhasznalorep = new GenericRepository<Felhasznalo>(App.databasePath);
            var felhasznaloLekerdezes = Felhasznalorep.GetAll();
            datagridFelhasznalok.ItemsSource = felhasznaloLekerdezes;

        }

        private void mentesBtn_Click(object sender, RoutedEventArgs e)
        {


            Termekek ujtermek = new Termekek(
                felhasznaloNevTextBox.Text,
                teljesNevTextBox.Text
            );
            var Felhasznalorep = new GenericRepository<Termekek>(App.databasePath);
            Felhasznalorep.insert(ujtermek);

            ReadDB();
        }




        private void torlesBtn_Click(object sender, RoutedEventArgs e)
        {
            var Felhasznalorep = new GenericRepository<Termekek>(App.databasePath);
            Felhasznalorep.delete(valasztottermek);

            ReadDB();
        }

        private void datagridFelhasznalok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (datagridFelhasznalok.SelectedItem != null)
            {
                valasztottermek = (Termekek)datagridFelhasznalok.SelectedItem;
                felhasznaloNevTextBox.Text = valasztottermek.Termeknev;
                teljesNevTextBox.Text = valasztottermek.Funkcio;
     
            }
        }

        private void modBtn_Click(object sender, RoutedEventArgs e)
        {



            valasztottermek.Termeknev = felhasznaloNevTextBox.Text;
            valasztottermek.Funkcio = teljesNevTextBox.Text;





            var Felhasznalorep = new GenericRepository<Felhasznalo>(App.databasePath);
            Felhasznalorep.insert(valasztottermek);

            ReadDB();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Visibility = Visibility.Hidden;
        }
    }
}
    