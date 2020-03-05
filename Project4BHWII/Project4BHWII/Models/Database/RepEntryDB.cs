using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Project4BHWII.Models.Database
{
    public class RepEntryDB : IRepEntry
    {
        private string _connectionString = "Server=localhost;Database=WebProjekt;Uid=root;Pwd=Sammiegsg9;";
        private MySqlConnection _connection = null;

        public void Open()
        {
            if (this._connection == null)
            {
                this._connection = new MySqlConnection(this._connectionString);
            }
            if (this._connection.State != ConnectionState.Open)
            {
                this._connection.Open();
            }
        }
        public void Close()
        {
            if (this._connection != null && (this._connection.State != ConnectionState.Closed))
            {
                this._connection.Close();
            }
        }

        public bool Insert(newEntry Entry)
        {
            DbCommand cmdInsert = _connection.CreateCommand();
            cmdInsert.CommandText = "INSET into entries values null,@userId,@titel,@entryText,@uploadData,@entryType";

            DbParameter paramUserId = cmdInsert.CreateParameter();
            paramUserId.ParameterName = "userId";
            paramUserId.Value = Session.Id;
            paramUserId
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
        public bool Update(int id, newEntry UpdatedEntry)
        {
            throw new NotImplementedException();
        }
        public List<newEntry> allEntries()
        {
            throw new NotImplementedException();
        }
    }
}