using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Models.ModelsDB
{
    internal class ClassRoomTopicsDB
    {

        private SqlCommand _command;
        private SqlDataReader _reader;
        private List<string> topics;
        private string query;

        /// <summary>
        /// Perform a database query to bring up all the topics that the salons have.
        /// </summary>
        /// <param name="currentConnection">The SqlConnection object representing the current database connection.</param>
        /// <returns>returns a list of the total Topics among all the salons in the database</returns>
        public List<string> GetTopics(SqlConnection currentConnection)
        {
            topics = new List<string>();

            query = "Select Tematica from Tematica_Salones";
            _command = new SqlCommand(query, currentConnection);
            _reader = _command.ExecuteReader();
            while (_reader.Read())
            {
                topics.Add(_reader.GetString(0));
            }
            _reader.Close();

            return topics;

        }


    }
}
