using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Collections.Specialized;

namespace UMS.Models.ModelsDB
{
    internal class OpenDbConnection
    {
        public OpenDbConnection() { }


        /// <summary>
        /// Opens a <see cref="SqlConnection"/> using the connection string specified in the configuration file.
        /// </summary>
        /// <returns>
        /// A <see cref="SqlConnection"/> object representing the opened database connection.
        /// </returns>
        public SqlConnection openConnection()
        {
            string stringConnection = ConfigurationManager.ConnectionStrings["StringConnection"].ToString();

            var connection = new SqlConnection(stringConnection);

            connection.Open();

            return connection;
        }
    }
}
