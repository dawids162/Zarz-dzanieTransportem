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
using System.Windows.Shapes;
using System.Data.SQLite;

namespace ZarządanieTransportem
{
    /// <summary>
    /// Interaction logic for Drivers.xaml
    /// </summary>
    public partial class Drivers : Window
    {
        public Drivers()
        {
            
            InitializeComponent();
            FillCombobox();
        }
        private string dbConnectionString = @"Data Source=E:\bazaDanych.s3db";


        void FillCombobox()
        {            
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            try
            {
                sqliteCon.Open();
                string Query = "select * from Drivers ";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                SQLiteDataReader dataReaderr = createCommand.ExecuteReader();
                while (dataReaderr.Read())
                {
                    string name = dataReaderr.GetString(1); //1 kolumna
                    string surname = dataReaderr.GetString(2); //2 kolumna
                    Surname_combo.Items.Add(name+" "+surname);

                }
                sqliteCon.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void AddDriverButton_Click(object sender, RoutedEventArgs e)
        {           
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            try
            {
                sqliteCon.Open();
                string Query = "insert into Drivers (ID, Name, Surname, Category) values('" + this.Id_txt.Text + "','" + this.Name_txt.Text + "','" + this.Surname_txt.Text + "','" + this.Category_txt.Text + "')";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                createCommand.ExecuteNonQuery();

                MessageBox.Show("Saved");
                sqliteCon.Close();
                this.Hide();
            }
            catch (Exception ex)
            {                   
                MessageBox.Show(ex.Message) ;
            }
        }
    }
}
