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

namespace Sajat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void felhasznaloMenu_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Panel.Children.Clear();
            Panel.Children.Add(new Views.UserControl_Felhasznalok());
        }

        private void vasarloMenu_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.AddChild(new Views.UserControl_Felhasznalok());
        }

        private void termekMenu_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.AddChild(new Views.UserControl_Felhasznalok());
        }
    }
}