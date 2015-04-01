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
using System.Windows.Shapes;

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
            if(LoginText.Text=="test" && HasloText.Text=="test")
            {
                this.form1.login = "test";
                this.form1.password = "test";
                this.Close();
            }
        }
    }
}
