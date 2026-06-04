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
using Sajat.Model;

namespace Sajat.Views
{
    /// <summary>
    /// Interaction logic for UserControl_Felhasznalok.xaml
    /// </summary>
    public partial class UserControl_Felhasznalok : UserControl
    {
        List<Felhasznalo> felhasznalok;
        Felhasznalo valasztottFelhasznalo;
        public UserControl_Felhasznalok()
        {
            InitializeComponent();
            felhasznalok = new List<Felhasznalo>();
            ReadDB();
           
            szerepkor.ItemsSource = Enum.GetNames(typeof(Szerepkor));

        }

   

        private void ReadDB()
        {
            szerepkor.SelectedItem = Enum.GetName(typeof(Szerepkor), Szerepkor.Vendeg);
            teljesNevTextBox.Text = "";
            felhasznaloNevTextBox.Text = "";
            jelszoBox.Password = "";

            var Felhasznalorep = new GenericRepository<Felhasznalo>(App.databasePath);
            var felhasznaloLekerdezes = Felhasznalorep.GetAll();
            datagridFelhasznalok.ItemsSource = felhasznaloLekerdezes;

        }

        private void mentesBtn_Click(object sender, RoutedEventArgs e)
        {
            string kivalasztottSzerepkorNev = (string)szerepkor.SelectedItem;
            Szerepkor kivalasztottSzerepkor = (Szerepkor)Enum.Parse(typeof(Szerepkor), kivalasztottSzerepkorNev);
            int kivalasztottszerepkorId = (int)kivalasztottSzerepkor;

            bool korozikValueTrue = korozik.IsChecked == true;

    
            Felhasznalo ujfelhasznalo = new Felhasznalo(
                felhasznaloNevTextBox.Text,
                teljesNevTextBox.Text,
                jelszoBox.Password,
                kivalasztottszerepkorId,
                korozikValueTrue
            );
            var Felhasznalorep = new GenericRepository<Felhasznalo>(App.databasePath);
            Felhasznalorep.insert(ujfelhasznalo);

            ReadDB();
        }




        private void torlesBtn_Click(object sender, RoutedEventArgs e)
        {
            var Felhasznalorep = new GenericRepository<Felhasznalo>(App.databasePath);
            Felhasznalorep.delete(valasztottFelhasznalo);

            ReadDB();
        }

        private void datagridFelhasznalok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (datagridFelhasznalok.SelectedItem != null)
            {
                valasztottFelhasznalo = (Felhasznalo)datagridFelhasznalok.SelectedItem;
                felhasznaloNevTextBox.Text = valasztottFelhasznalo.FelhasznaloNev;
                teljesNevTextBox.Text = valasztottFelhasznalo.TeljesNev;
                szerepkor.SelectedItem = Enum.GetName(typeof(Szerepkor), valasztottFelhasznalo.Szerepkor);
            }
        }

        private void modBtn_Click(object sender, RoutedEventArgs e)
        {
            string kivalasztottSzerepkorNev = (string)szerepkor.SelectedItem;
            Szerepkor kivalasztottSzerepkor = (Szerepkor)Enum.Parse(typeof(Szerepkor), kivalasztottSzerepkorNev);
            int kivalasztottszerepkorId = (int)kivalasztottSzerepkor;

            valasztottFelhasznalo.FelhasznaloNev = felhasznaloNevTextBox.Text;
            valasztottFelhasznalo.TeljesNev = teljesNevTextBox.Text;
            valasztottFelhasznalo.Szerepkor = kivalasztottszerepkorId;

            

         
            var Felhasznalorep = new GenericRepository<Felhasznalo>(App.databasePath);
            Felhasznalorep.insert(valasztottFelhasznalo);

            ReadDB();

        }



       
    }
}
