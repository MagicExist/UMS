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

        /// <summary>
        ///  Performs a database query to fetch all blocks that have salons
        /// </summary>
        /// <param name="currentConnection">The SqlConnection object representing the current database connection.</param>
        /// <returns>returns a list of the blocks in which each classroom is located</returns>
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
