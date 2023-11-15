using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Models.ModelsDB
{
    internal class ClassRoomStatesDB
    {

        private SqlCommand _command;
        private SqlDataReader _reader;
        private List<string> states;
        private string query;

        /// <summary>
        /// Performs a query to the database to fetch all the statuses that the classrooms have.
        /// </summary>
        /// <param name="currentConnection">The SqlConnection object representing the current database connection.</param>
        /// <returns>returns a list of the total statuses among all the salons in the database</returns>
        public List<string> GetStates(SqlConnection currentConnection)
        {
            states = new List<string>();

            query = "select Estado from Estado_Salones";
            _command = new SqlCommand(query, currentConnection);
            _reader = _command.ExecuteReader();
            while (_reader.Read())
            {
                states.Add(_reader.GetString(0));
            }
            _reader.Close();

            return states;

        }

    }
}
