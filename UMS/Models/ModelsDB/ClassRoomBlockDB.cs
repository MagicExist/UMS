using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Models.ModelsDB
{
    internal class ClassRoomBlockDB
    {

        private SqlCommand _command;
        private SqlDataReader _reader;
        private List<string> blocks;
        private string query;

        public List<string> GetBlocks(SqlConnection currentConnection)
        {
            blocks = new List<string>();

            query = "select distinct Convert(int,LEFT(CodigoSalon, CHARINDEX('-', CodigoSalon) -1)) as Bloque from Salones order by Bloque";
            _command = new SqlCommand(query, currentConnection);
            _reader = _command.ExecuteReader();
            while (_reader.Read())
            {
                blocks.Add(_reader.GetInt32(0).ToString());
            }
            _reader.Close();

            return blocks;

        }
    }
}
