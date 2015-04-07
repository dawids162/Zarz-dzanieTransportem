using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace ZarządanieTransportem
{
    static class ConnectDataBase
    {
        static public SQLiteDataAdapter m_oDataAdapter = null;
        static public DataSet m_oDataSet = null;
        static public DataTable m_oDataTable = null;
        static public SQLiteConnection oSQLiteConnection;
        static public void Connect()
        {
            oSQLiteConnection = new SQLiteConnection(@"Data Source=C:\Users\Dawid\Desktop\bazaDanych.s3db");
        }
        static public DataTable Commend(string commend)
        {
            m_oDataSet = null;
            m_oDataTable = null;
            m_oDataAdapter = null;
            SQLiteCommand oCommand = oSQLiteConnection.CreateCommand();
            oCommand.CommandText = commend;
            m_oDataAdapter = new SQLiteDataAdapter(oCommand.CommandText, oSQLiteConnection);
            SQLiteCommandBuilder oCommandBuilder = new SQLiteCommandBuilder(m_oDataAdapter);
            m_oDataSet = new DataSet();
            m_oDataAdapter.Fill(m_oDataSet);
            m_oDataTable = m_oDataSet.Tables[0];
            return m_oDataTable;
        }
    }
}
