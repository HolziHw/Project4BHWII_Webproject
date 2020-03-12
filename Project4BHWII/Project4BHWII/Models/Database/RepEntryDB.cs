using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using Project4BHWII.Models;

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

        public bool Insert(Entry Entry, string username)
        {

            DbCommand cmdInsert = this._connection.CreateCommand();
            cmdInsert.CommandText = "INSERT into entries values (null, @userName, @titel, @entryText, @uploadData, @entryType)";
            
            DbParameter paramUserId = cmdInsert.CreateParameter();
            paramUserId.ParameterName = "userName";
            paramUserId.Value = username;
            paramUserId.DbType = DbType.String;
            
            DbParameter paramTitel = cmdInsert.CreateParameter();
            paramTitel.ParameterName = "titel";
            paramTitel.Value = Entry.Titel;
            paramTitel.DbType = DbType.String;

            DbParameter paramText = cmdInsert.CreateParameter();
            paramText.ParameterName = "entryText";
            paramText.Value = Entry.EntryText;
            paramText.DbType = DbType.String;

            DbParameter paramUpload = cmdInsert.CreateParameter();
            paramUpload.ParameterName = "uploadData";
            paramUpload.Value = Entry.UploadDataURL;
            paramUpload.DbType = DbType.String;

            DbParameter paramType = cmdInsert.CreateParameter();
            paramType.ParameterName = "entryType";
            paramType.Value = Entry.EntryType;
            paramType.DbType = DbType.Int32;

            cmdInsert.Parameters.Add(paramUserId);
            cmdInsert.Parameters.Add(paramTitel);
            cmdInsert.Parameters.Add(paramText);
            cmdInsert.Parameters.Add(paramUpload);
            cmdInsert.Parameters.Add(paramType);

            return cmdInsert.ExecuteNonQuery() == 1;
        }

        public bool Delete(int id)
        {
            DbCommand cmdDelete = _connection.CreateCommand();
            cmdDelete.CommandText = "DELETE from entries where id = @EntryId";

            DbParameter paramId = cmdDelete.CreateParameter();
            paramId.ParameterName = "EntryId";
            paramId.Value = id;
            paramId.DbType = DbType.Int32;

            cmdDelete.Parameters.Add(paramId);

            return cmdDelete.ExecuteNonQuery() == 1;
        }
        public bool Update(int id, Entry UpdatedEntry)
        {
            DbCommand cmdUpdate = _connection.CreateCommand();
            cmdUpdate.CommandText = "UPDATE entires SET id = id, id_name = id_name,titel = @Titel, entryText = @entryText, uploadData = @UploadData,EntryTyp = @EntryTyp";


            DbParameter paramTitel = cmdUpdate.CreateParameter();
            paramTitel.ParameterName = "Titel";
            paramTitel.Value = UpdatedEntry.Titel;
            paramTitel.DbType = DbType.String;

            DbParameter paramText = cmdUpdate.CreateParameter();
            paramText.ParameterName = "entryText";
            paramText.Value = UpdatedEntry.EntryText;
            paramText.DbType = DbType.String;

            DbParameter paramData = cmdUpdate.CreateParameter();
            paramData.ParameterName = "UploadData";
            paramData.Value = UpdatedEntry.UploadDataURL;
            paramData.DbType = DbType.String;

            DbParameter paramTyp = cmdUpdate.CreateParameter();
            paramTyp.ParameterName = "EntryTyp";
            paramTyp.Value = UpdatedEntry.EntryType;
            paramTyp.DbType = DbType.Int32;


            cmdUpdate.Parameters.Add(paramTitel);
            cmdUpdate.Parameters.Add(paramText);
            cmdUpdate.Parameters.Add(paramData);
            cmdUpdate.Parameters.Add(paramTyp);

            return cmdUpdate.ExecuteNonQuery() == 1;
        }

        public List<Entry> allEntries()
        {
            List<Entry> entries = new List<Entry>();
            DbCommand cmdAllEntries = _connection.CreateCommand();
            cmdAllEntries.CommandText = "select id_name,titel,entryText,uploadData,EntryTyp from entries; ";

            using(DbDataReader reader = cmdAllEntries.ExecuteReader())
            {
                while(reader.Read())
                {
                    entries.Add(
                        new Entry
                        {
                            UserName = Convert.ToString(reader[0]),
                            Titel = Convert.ToString(reader[1]),
                            EntryText = Convert.ToString(reader[2]),
                            UploadDataURL = Convert.ToString(reader[3]),
                            EntryType = (EntryType)Convert.ToInt32(reader[4])
                        });
                }
            }
            return entries;
        }
    }
}