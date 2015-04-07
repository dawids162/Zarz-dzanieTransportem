using System;
using System.Collections.Generic;
using System.Data;
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

        public string login, permissions = "x";
        public MainWindow()
        {
            InitializeComponent();
            ConnectDataBase.Connect();
            LoginWindow LoginWindow1 = new LoginWindow(this);
            // Logowanie1.Owner = this;
            LoginWindow1.ShowDialog();
            if (permissions == "x") this.Close();
            unlock(permissions);
            Mapa.Navigate("https://mapa.targeo.pl");
          
            
            
        }
        /// <summary>
        /// metoda przyjmuje uprawnienia uzytkownika i odblokowuje w drzewie menu te dla których wartosc jest rowna 1
        /// </summary>
        /// <param name="permissions"></param>
        private void unlock(string permissions)
        {
            try
            {
                if (permissions[0] == '1')
                {

                    Mapa.Visibility = Visibility.Visible;
                    TreeMapa.IsEnabled = true;
                }
                if (permissions[1] == '1')
                {
                    TreePracownicy.IsEnabled = true;
                }
                if (permissions[2] == '1')
                {
                    TreeSrodkitrwale.IsEnabled = true;
                }
                if (permissions[3] == '1')
                {
                    TreeUslugiTransportowe.IsEnabled = true;
                }
                if (permissions[4] == '1')
                {
                    TreePaliwo.IsEnabled = true;
                }
                if (permissions[5] == '1')
                {
                    GridStatus.IsEnabled = true;
                }
                if (permissions[6] == '1')
                {
                    TreeAdmin.IsEnabled = true;
                    TreeAdmin.Visibility = Visibility.Visible;
                }
                if (permissions[7] == '1')
                {
                   // TreeAdmin.IsEnabled = true;
                    //TreeAdmin.Visibility = Visibility.Visible;
                }
            }
            catch { }
        }
        /// <summary>
        /// metoda do ukrywanie nie potrzebnych obiektów w czasie prechodzenia po menu
        /// po jej wywolaniu powinno ukrywac sie wszystko, za odkrycie odpowiednich obiektow odpowiadaja juz odpowiednie metody Click_Tree
        /// </summary>
        private void hidden()
        {
            GridAdmin.Visibility = Visibility.Hidden;
            GridAdmin_AddUser.Visibility = Visibility.Hidden;
            Mapa.Visibility = Visibility.Hidden;
        }
        private void Click_TreeAdmin(object sender, MouseButtonEventArgs e)
        {
            hidden();
            GridAdmin.Visibility = Visibility.Visible;
        }

        private void Click_TreeMap(object sender, MouseButtonEventArgs e)
        {
            hidden();
            Mapa.Visibility = Visibility.Visible;
            AddUser_GridAdmin_button.IsEnabled = true;
        }

        private void AddUser_GridAdmin_button_Click(object sender, RoutedEventArgs e)
        {
            GridAdmin_AddUser.Visibility = Visibility.Visible;
        }

        private void button_AddUserGrid_SaveUser_Click(object sender, RoutedEventArgs e)
        {
            ConnectDataBase.Connect();
            ConnectDataBase.Commend("select * from Customers");
            DataRow oDataRow = ConnectDataBase.m_oDataTable.NewRow();
            oDataRow[0] = Textboc_AddUsersGrid_login.Text;
            oDataRow[1] = Textboc_AddUsersGrid_password.Text;
            oDataRow[2] = permissionsNewUser();
            ConnectDataBase.m_oDataTable.Rows.Add(oDataRow);
            ConnectDataBase.m_oDataAdapter.Update(ConnectDataBase.m_oDataSet);
            ConnectDataBase.oSQLiteConnection.Close();
        }
        private string permissionsNewUser()
        {
            string permissionsUser = "";
            if (CheckBox_AddUser_Map.IsChecked == true) permissionsUser += 1;
            else permissionsUser += 0;
            if (CheckBox_AddUser_Employees.IsChecked == true) permissionsUser += 1;
            else permissionsUser += 0;
            if (CheckBox_AddUser_Equipment.IsChecked == true) permissionsUser += 1;
            else permissionsUser += 0;
            if (CheckBox_AddUser_transport.IsChecked == true) permissionsUser += 1;
            else permissionsUser += 0;
            if (CheckBox_AddUser_Fuel.IsChecked == true) permissionsUser += 1;
            else permissionsUser += 0;
            if (ChackBox_AddUser_Admin.IsChecked == true) permissionsUser += 1;
            else permissionsUser += 0;
            return permissionsUser;
        }
    }
}
