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
