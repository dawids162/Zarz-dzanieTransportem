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
        static private SQLiteDataAdapter m_oDataAdapter = null;
        static private DataSet m_oDataSet = null;
        static private DataTable m_oDataTable = null;
        static SQLiteConnection oSQLiteConnection;
        static public void Connect()
        {
            oSQLiteConnection = new SQLiteConnection(@"Data Source=bazaDanych.s3db");
        }
        static public DataTable Commend(string commend)
        {
            m_oDataSet = null;
            m_oDataTable = null;
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
