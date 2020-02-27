using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Project4BHWII.Models.Database
{
    public class RepUserDB : IRepUser
    {
        private string _connectionString = "Server=localhost;Database=einfuehrungBsp;Uid=root;Pwd=Sammiegsg9;";
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

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(User user)
        {
            if(user == null)
            {
                return false;
            }

            IDbCommand cmdInsert = 
        }
        public User Login(UserLogin user)
        {
            throw new NotImplementedException();
        }



        public bool UpdateUserData(int id, User newUserData)
        {
            throw new NotImplementedException();
        }
    }
}