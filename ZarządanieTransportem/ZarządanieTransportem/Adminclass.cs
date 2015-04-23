using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ZarządanieTransportem
{
    public partial class MainWindow : Window
    {
        private void button_GridAdmin_DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            Textblock_GridAdmin_Info.Text = "";
            ComboBox_GridAdminUser_ListCustomers.Items.Clear();
            GridDeleteUser_GridAdminUser.Visibility = Visibility.Visible;
            GridAddUser_GridAdminAddUser.Visibility = Visibility.Hidden;
            Textblock_GridAdmin_Info.Text = "";
            GridAdmin_AddUser.Visibility = Visibility.Visible;
            ConnectDataBase.Connect();
            ConnectDataBase.Commend("select * from Customers");
            for (int i = 0; i < ConnectDataBase.m_oDataTable.Rows.Count; i++)
            {
                if (ConnectDataBase.m_oDataTable.Rows[i]["Login"].ToString() != "Admin")
                    ComboBox_GridAdminUser_ListCustomers.Items.Add(ConnectDataBase.m_oDataTable.Rows[i]["Login"].ToString());
            }
            
        }
        private void AddUser_GridAdmin_button_Click(object sender, RoutedEventArgs e)
        {
            Textblock_GridAdmin_Info.Text = "";
            GridAdmin_AddUser.Visibility = Visibility.Visible;
            GridAddUser_GridAdminAddUser.Visibility = Visibility.Visible;
            GridDeleteUser_GridAdminUser.Visibility = Visibility.Hidden;
            Textboc_AddUsersGrid_login.Text = "login";
            Textboc_AddUsersGrid_password.Text = "hasło";
        }
        /// <summary>
        /// dodaje nowego użytkownika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            Textblock_GridAdmin_Info.Text = "OK!";
            GridAddUser_GridAdminAddUser.Visibility = Visibility.Hidden;
            GridAdmin_AddUser.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// odczytuje nadane uprawnienia dla nowego uzytkownika
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// wyszukuje wybranego uzytkownika w combobox, jak go odnajdzie usuwa z bazy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_GridAdminUser_DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ConnectDataBase.m_oDataTable.Rows.Count; i++)
            {
                if (ConnectDataBase.m_oDataTable.Rows[i]["Login"].ToString() == ComboBox_GridAdminUser_ListCustomers.Text)
                {
                    ConnectDataBase.m_oDataTable.Rows[i].Delete();
                }
            }
            ConnectDataBase.m_oDataAdapter.Update(ConnectDataBase.m_oDataSet);
            Textblock_GridAdmin_Info.Text = "OK!";
            GridDeleteUser_GridAdminUser.Visibility = Visibility.Hidden;
        }
    }
}
