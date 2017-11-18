using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CS350ExamASP.Models
{
    public class DBContext
    {

        /*
         * 
         * This class loads all data from the MySQL database
         * It loads all of the users in to a list
         * 
         * 
         */

        public string ConnectionString { get; set; }
        public DBContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * from user", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User()
                        {
                            userID = reader.GetString("userID"),
                            firstName = reader.GetString("firstName"),
                            lastName = reader.GetString("lastName"),
                            email = reader.GetString("email"),
                            passSalt = reader.GetString("passSalt"),
                            passHash = reader.GetString("passHash"),
                            posts = reader.GetString("posts").Split(',').Select(i => int.Parse(i)).ToList(),
                            friends = reader.GetString("friends").Split(',').Select(i => Convert.ToString(i)).ToList()
                        });
                    }
                }
            }

            return users;
        }
    }
}
