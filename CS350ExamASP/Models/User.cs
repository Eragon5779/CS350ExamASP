using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CS350ExamASP.Models
{
    public class User
    {

        private DBContext dbconnection;

        // username
        public string userID;
        // user name
        public string firstName;
        public string lastName;
        public string email;
        // password hashing information
        public string passSalt;
        public string passHash;
        // list of post IDs 
        public List<int> posts;
        // list of friend userIDs
        public List<string> friends;

        public bool userLogin(string userName)
        {

        }


    }
}
