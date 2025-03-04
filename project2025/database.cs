using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;
namespace project2025
{
    class database
    {
        string serveraddress;
        string username;
        string password;
        string databasename;
        string connectionString;
        MySqlConnection connection;
        public database()
        {
            //szerver címe
            serveraddress = "localhost";
            username = "root";
            password = "";
            databasename = "data";
            connectionString = $"Server={serveraddress};Database={databasename};User={username};Password={password}";
            connection = new MySqlConnection(connectionString);


        }
        public List<users> readall()
        {
            List<users> userss = new List<users>();
            try
            {
                connection.Open();
                string query = "select * from users";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    //MessageBox.Show(read.ToString());
                    /*MessageBox.Show(read.GetString(read.GetOrdinal("Make")));
                    MessageBox.Show(read.GetInt32(read.GetOrdinal("YeaR")).ToString());
                    MessageBox.Show(read.GetString(read.GetOrdinal("Model")));
                    MessageBox.Show(read.GetInt32(read.GetOrdinal("Power")).ToString());*/
                    users oneuser = new users();
                    oneuser.username = read.GetString(read.GetOrdinal("username"));
                    oneuser.password = read.GetString(read.GetOrdinal("password"));
                    oneuser.email = read.GetString(read.GetOrdinal("email"));
                    oneuser.points = read.GetInt32(read.GetOrdinal("points"));
                    userss.Add(oneuser);
                }

                read.Close();
                command.Dispose();
                connection.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show("A Hiba :" + e.Message);

            }
            return userss;
        }
        public void insetOneCar(users oneuser)
        {
            try
            {
                connection.Open();
                string query = $"insert into auto (make, model, year, power) values('{oneuser.make}','{oneuser.model}',{oneuser.year},{oneuser.power})";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("A Hiba :" + e.Message);
            }
        }
    }
    public class users
    {
        public string username { get; set; }
        public string password { get; set; }
        public String email { get; set; }
        public int points { get; set; }
    }
}
