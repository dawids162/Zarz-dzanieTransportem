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

namespace ZarządanieTransportem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string login, haslo;
        public MainWindow()
        {
            InitializeComponent();
            Logowanie Logowanie1 = new Logowanie(this);
           // Logowanie1.Owner = this;
            Logowanie1.ShowDialog();
           if(login=="test" && login == "test")
           {
               Mapa.Navigate("https://mapa.targeo.pl");
               odblokujWszystko();
           }
            
            
        }
        private void odblokujWszystko()
        {
            TreePracownicy.IsEnabled = true;
            TreeSrodkitrwale.IsEnabled = true;
            TreeUslugiTransportowe.IsEnabled = true;
            TreePaliwo.IsEnabled = true;
            GridStatus.IsEnabled = true;
            Mapa.IsEnabled = true;
        }
    }
}
