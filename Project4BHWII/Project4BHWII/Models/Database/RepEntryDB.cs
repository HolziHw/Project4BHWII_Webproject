﻿using MySql.Data.MySqlClient;
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

            DbCommand cmdInsert = _connection.CreateCommand();
            cmdInsert.CommandText = "INSET into entries values null,@userName,@titel,@entryText,@uploadData,@entryType";
            
            DbParameter paramUserId = cmdInsert.CreateParameter();
            paramUserId.ParameterName = "userId";
            paramUserId.Value = "toBeImplementet";
            paramUserId.DbType = DbType.String;
            
            DbParameter paramTitel = cmdInsert.CreateParameter();
            paramTitel.ParameterName = "titel";
            paramTitel.Value = Entry.Titel;
            paramTitel.DbType = DbType.String;

            DbParameter paramText = cmdInsert.CreateParameter();
            paramTitel.ParameterName = "entryText";
            paramTitel.Value = Entry.EntryText;
            paramTitel.DbType = DbType.String;

            DbParameter paramUpload = cmdInsert.CreateParameter();
            paramTitel.ParameterName = "uploadData";
            paramTitel.Value = Entry.UploadDataURL;
            paramTitel.DbType = DbType.String;

            DbParameter paramType = cmdInsert.CreateParameter();
            paramTitel.ParameterName = "entryType";
            paramTitel.Value = Entry.EntryType;
            paramTitel.DbType = DbType.Int32;

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
            DbCommand cmdUpadate = _connection.CreateCommand();
            cmdUpadate.CommandText = "UPDATE entires SET id = id, id_name = id_name,titel = @Titel, entryText = @entryText, uploadData = @UploadData,EntryTyp = @ EntryTyp";



        }

        public List<Entry> allEntries()
        {
            List<Entry> entries = new List<Entry>();
            DbCommand cmdAllEntries = _connection.CreateCommand();
            cmdAllEntries.CommandText = "select e.titel,e.entryText,e.uploadData,e.EntryTyp,u.username from entries as e inner join users as u on e.id_user = u.id; ";

            using(DbDataReader reader = cmdAllEntries.ExecuteReader())
            {
                reader.Read();
                while(reader.Read())
                {
                    entries.Add(
                        new Entry
                        {
                            UserName = Convert.ToString(reader[5]),
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