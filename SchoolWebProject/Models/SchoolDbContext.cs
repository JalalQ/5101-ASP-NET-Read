using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//After installing MySQL.Data. Connects wit MySQL. Keep MAMP open and running.
using MySql.Data.MySqlClient;


// The following code has been largely taken from:
// https://github.com/christinebittle/BlogProject_2/blob/master/BlogProject/Models/BlogDbContext.cs

namespace SchoolWebProject.Models
{
    public class SchoolDbContext
    {

        //Values set based on my own local MySQL database
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "school"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        //ConnectionString is a series of credentials used to connect to the database.
        protected static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }
        //This is the method we actually use to get the database!
        /// <summary>
        /// Returns a connection to the blog database.
        /// </summary>
        /// <example>
        /// private BlogDbContext Blog = new BlogDbContext();
        /// MySqlConnection Conn = Blog.AccessDatabase();
        /// </example>
        /// <returns>A MySqlConnection Object</returns>
        public MySqlConnection AccessDatabase()
        {
            //We are instantiating the MySqlConnection Class to create an object
            //the object is a specific connection to our blog database on port 3307 of localhost
            return new MySqlConnection(ConnectionString);
        }
    }
}