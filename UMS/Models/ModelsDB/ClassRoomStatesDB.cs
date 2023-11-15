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
