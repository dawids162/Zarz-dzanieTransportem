using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
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
using System.Threading;

namespace ZarządanieTransportem
{
    /// <summary>
    /// Interaction logic for Logowanie.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        MainWindow form1;
        public LoginWindow(MainWindow form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }

        private void ButtonLogowanie_Click(object sender, RoutedEventArgs e)
        {
            infoBox.Text = "";
            DataTable table = ConnectDataBase.Commend("SELECT * FROM Customers WHERE Login=='"+LoginText.Text+"' AND Password=='"+HasloText.Text+"'");
            
            if(table.Rows.Count > 0)
            {
                this.form1.login = "test";
                this.form1.password = "test";
                this.Close();
            }
            else
            {
                infoBox.Text = "NIEPOPRAWNE DANE";
            }
        }
    }
}
