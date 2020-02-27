using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
            DbCommand cmdDelete = this._connection.CreateCommand();
            cmdDelete.CommandText = "DELETE FROM users where id=@userId";

            //Parameter belegen
            DbParameter paramId = cmdDelete.CreateParameter();
            paramId.ParameterName = "userId";
            paramId.Value = id;
            //id ist der Übergabe wert
            paramId.DbType = DbType.Int32;

            //Parameter dem Command hinzufügen
            cmdDelete.Parameters.Add(paramId);

            //Command ausführen
            return cmdDelete.ExecuteNonQuery() == 1;    //gibt true zurück wenn genau ein Usr gelöscht wurde
        }

        public List<User> GetAllUser()
        {

            List<User> users = new List<User>();

            DbCommand cmdAllUsers = this._connection.CreateCommand();
            cmdAllUsers.CommandText = "SELECT * FROM users";

            // ExecuteReader() wird immer bei selct verwendet
            // zeilenweise Abfrage der Daten möglich
            using (DbDataReader reader = cmdAllUsers.ExecuteReader())
            {
                while (reader.Read()) //mit read wird der nächste Datenssatz gelesen
                {
                    users.Add(
                        new User
                        {
                            // Id .. so lautet der Name in der Class User, id so lautet der Spaltenname in der DB
                            Id = Convert.ToInt32(reader["id"]),
                            Firstname = Convert.ToString(reader["firstname"]),
                            Lastname = Convert.ToString(reader["lastname"]),
                            Gender = (Gender)Convert.ToInt32(reader["gender"]),
                            Birthdate = Convert.ToDateTime(reader["birthdate"]),
                            Username = Convert.ToString(reader["username"]),
                            Password = ""
                        });
                }
            }
            return users;
        }

        public User GetUser(int id)
        {
            DbCommand cmdOneUser = this._connection.CreateCommand();
            cmdOneUser.CommandText = "SELECT * from users where id = @userId";

            DbParameter paramId = cmdOneUser.CreateParameter();
            paramId.ParameterName = "userId";
            paramId.Value = id;
            paramId.DbType = DbType.Int32;

            cmdOneUser.Parameters.Add(paramId);

            //bei SELECT abfragen müssen wir immer executeReader aufrufen

            using (DbDataReader reader = cmdOneUser.ExecuteReader())
            {
                if (!reader.HasRows) //kein Datensatz vorhanden
                {
                    return null;
                }
                reader.Read(); //Dieser Aufruf ist notwendig, da damit der erste Datensatz gelesen wird.
                return new User
                {
                    // Id .. so lautet der Name in der Class User, id so lautet der Spaltenname in der DB
                    Id = Convert.ToInt32(reader["id"]),
                    Firstname = Convert.ToString(reader["firstname"]),
                    Lastname = Convert.ToString(reader["lastname"]),
                    Gender = (Gender)Convert.ToInt32(reader["gender"]),
                    Birthdate = Convert.ToDateTime(reader["birthdate"]),
                    Username = Convert.ToString(reader["username"]),
                    Password = ""
                };
            }
        }

        public bool Insert(User user)
        {
            // 1. Parameter überprüfen

            if (user == null)
            {
                return false;
            }

            // ein leeres SQL Command erzeugen
            DbCommand cmdInsert = this._connection.CreateCommand();

            // @firstname, @lastname, ... Parameter => sie verwenden SQL-Injections
            // müssen immer verwednet werden, wenn es sich um Daten des Benutzers handelt
            cmdInsert.CommandText = "INSERT INTO users values (null, @firstname, @lastname, @gender, @birthdate,@username,sha2(@password,512))";


            // Parameter erzeugt
            DbParameter paramFN = cmdInsert.CreateParameter();
            paramFN.ParameterName = "firstname";
            paramFN.Value = user.Firstname;
            paramFN.DbType = DbType.String;

            DbParameter paramLN = cmdInsert.CreateParameter();
            paramLN.ParameterName = "lastname";
            paramLN.Value = user.Lastname;
            paramLN.DbType = DbType.String;

            DbParameter paramGender = cmdInsert.CreateParameter();
            paramGender.ParameterName = "gender";
            paramGender.Value = user.Gender;
            paramGender.DbType = DbType.Int32;

            DbParameter paramBD = cmdInsert.CreateParameter();
            paramBD.ParameterName = "birthdate";
            paramBD.Value = user.Birthdate;
            paramBD.DbType = DbType.Date;

            DbParameter paramUN = cmdInsert.CreateParameter();
            paramUN.ParameterName = "username";
            paramUN.Value = user.Username;
            paramUN.DbType = DbType.String;

            DbParameter paramPW = cmdInsert.CreateParameter();
            paramPW.ParameterName = "password";
            paramPW.Value = user.Password;
            paramPW.DbType = DbType.String;

            // Parameter mit dem Comment verbinden
            cmdInsert.Parameters.Add(paramFN);
            cmdInsert.Parameters.Add(paramLN);
            cmdInsert.Parameters.Add(paramGender);
            cmdInsert.Parameters.Add(paramBD);
            cmdInsert.Parameters.Add(paramUN);
            cmdInsert.Parameters.Add(paramPW);

            // ExecuteNonQuery wird bei insert verwendet und liefert die Anzahl der geändeten, gelöschent, ... Zeilen zurück
            return cmdInsert.ExecuteNonQuery() == 1;

            if (cmdInsert.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool UpdateUserData(int id, User newUserData)
        {
            DbCommand cmdUpdate = this._connection.CreateCommand();
            cmdUpdate.CommandText = "UPDATE users SET firstname=@firstname, lastname = @lastname, gender = @gender, birthdate=@birthdate, password =sha2(@password, 512) where id=@userId";

            DbParameter paramFirstname = cmdUpdate.CreateParameter();
            paramFirstname.ParameterName = "firstname";
            paramFirstname.Value = newUserData.Firstname;
            paramFirstname.DbType = DbType.String;

            DbParameter paramLastname = cmdUpdate.CreateParameter();
            paramLastname.ParameterName = "lastname";
            paramLastname.Value = newUserData.Lastname;
            paramLastname.DbType = DbType.String;

            DbParameter paramGender = cmdUpdate.CreateParameter();
            paramFirstname.ParameterName = "gender";
            paramFirstname.Value = newUserData.Gender;
            paramFirstname.DbType = DbType.Int32;

            DbParameter paramBithdate = cmdUpdate.CreateParameter();
            paramFirstname.ParameterName = "birthdate";
            paramFirstname.Value = newUserData.Birthdate;
            paramFirstname.DbType = DbType.Date;

            DbParameter paramPassword = cmdUpdate.CreateParameter();
            paramFirstname.ParameterName = "password";
            paramFirstname.Value = newUserData.Password;
            paramFirstname.DbType = DbType.String;

            DbParameter paramUpd = cmdUpdate.CreateParameter();
            paramUpd.ParameterName = "userId";
            paramUpd.Value = id;
            paramUpd.DbType = DbType.Int32;

            cmdUpdate.Parameters.Add(paramFirstname);
            cmdUpdate.Parameters.Add(paramLastname);
            cmdUpdate.Parameters.Add(paramGender);
            cmdUpdate.Parameters.Add(paramBithdate);
            cmdUpdate.Parameters.Add(paramPassword);

            return cmdUpdate.ExecuteNonQuery() == 1;
        }

        public User Login(UserLogin user)
        {
            DbCommand cmdLogin = this._connection.CreateCommand();
            cmdLogin.CommandText = "SELECT * from users where username = @username and password = sha2(@password, 512)";

            DbParameter paramUsername = cmdLogin.CreateParameter();
            paramUsername.ParameterName = "username";
            paramUsername.Value = user.Username;
            paramUsername.DbType = DbType.String;

            DbParameter paramPwd = cmdLogin.CreateParameter();
            paramPwd.ParameterName = "password";
            paramPwd.Value = user.Password;
            paramPwd.DbType = DbType.String;

            cmdLogin.Parameters.Add(paramUsername);
            cmdLogin.Parameters.Add(paramPwd);

            using (DbDataReader reader = cmdLogin.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return null;
                }
                reader.Read(); //Dieser Aufruf ist notwendig, da damit der erste Datensatz gelesen wird.
                return new User
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Firstname = Convert.ToString(reader["firstname"]),
                    Lastname = Convert.ToString(reader["lastname"]),
                    Gender = (Gender)Convert.ToInt32(reader["gender"]),
                    Birthdate = Convert.ToDateTime(reader["birthdate"]),
                    Username = Convert.ToString(reader["username"]),
                    Password = ""
                };
            }
        }
    }
}