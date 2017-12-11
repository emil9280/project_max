using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Threading;

namespace bank
{
    class MySQlbalance
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
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
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("cannot connect to server");
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
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(5000);
                return false;
            }
        }
        public List<string>[] balanc()
        {
            string query = "SELECT * FROM bankusers";

            List<string>[] list = new List<string>[4];
            list[0] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();

            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list[0].Add(dataReader["username"] + "");
                    list[2].Add(dataReader["balanc1"] + "");
                    list[3].Add(dataReader["balanc2"] + "");
                    list[4].Add(dataReader["account"] + "");
                }

                dataReader.Close();
                this.CloseConnection();
                return list;
            }
            else return list;
        }
    }
}