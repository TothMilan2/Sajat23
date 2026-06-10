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
            

            var Termekrep = new GenericRepository<Termekek>(App.databasePath);
            var felhasznaloLekerdezes = Termekrep.GetAll();
            datagridFelhasznalok.ItemsSource = felhasznaloLekerdezes;

        }

        private void mentesBtn_Click(object sender, RoutedEventArgs e)
        {


            
        }




        private void torlesBtn_Click(object sender, RoutedEventArgs e)
        {
            var Termekrep = new GenericRepository<Termekek>(App.databasePath);
            Termekrep.delete(valasztottermek);

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





            var Termekrep = new GenericRepository<Termekek>(App.databasePath);
            Termekrep.insert(valasztottermek);

            ReadDB();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void mentesBtn_Click_1(object sender, RoutedEventArgs e)
        {
            Termekek ujtermek = new Termekek(
                felhasznaloNevTextBox.Text,
                teljesNevTextBox.Text
            );
            var Termekrep = new GenericRepository<Termekek>(App.databasePath);
            Termekrep.insert(ujtermek);

            ReadDB();
        }
    }
}
    