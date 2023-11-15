using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Models.ModelsDB
{
    internal class DaysDB
    {

        private SqlCommand _command;
        private SqlDataReader _reader;
        private List<string> days;
        private string query;

        /// <summary>
        /// Retrieves a list of days from the database.
        /// </summary>
        /// <param name="currentConnection">The SqlConnection object representing the database connection.</param>
        /// <returns>A List of strings representing the days.</returns>
        public List<string> GetDays(SqlConnection currentConnection)
        {
            days = new List<string>();

            query = "select Dia from Dia_Clases";
            _command = new SqlCommand(query, currentConnection);
            _reader = _command.ExecuteReader();
            while (_reader.Read())
            {
                days.Add(_reader.GetString(0));
            }
            _reader.Close();

            return days;

        }

    }
}
