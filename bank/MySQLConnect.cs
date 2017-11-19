using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Threading;

namespace bank
{
    class MySQLConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public MySQLConnect()
        {
            Initiallize();
        }

        private void Initiallize()
        {
            server = "localhost";
            database = "users";
            uid = "root";
            password = "3milHM9685";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch(MySqlException ex)
            {
                switch(ex.Number)
                {
                    case 0:
                        Console.WriteLine("cannot connect to server");
                        Thread.Sleep(5000);
                        break;

                    case 1045:
                        Console.WriteLine("invalid username/password for the database");
                        Thread.Sleep(5000);
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(5000);
                return false;
            }
        }

        public List<string>[] SelectLogin()
        {
            string query = "SELECT * FROM bankusers";

            List<string>[] list = new List<string>[2];
            list[0] = new List<string>();
            list[1] = new List<string>();

            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list[0].Add(dataReader["username"] + "");
                    list[1].Add(dataReader["password"] + "");
                }

                dataReader.Close();
                this.CloseConnection();
                return list;
            }
            else return list;
        }
    }
}
