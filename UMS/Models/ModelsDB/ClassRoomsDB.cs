using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Models.ModelsDB
{
    internal class ClassRoomsDB
    {
        private SqlCommand _command;
        private SqlDataReader _reader;
        private List<ClassRoom> listClassroom;
        private string query;


        /// <summary>
        /// Loads a list of ClassRoom objects from the "Salones" table in the database.
        /// </summary>
        /// <param name="currentConnection">The SqlConnection object representing the current database connection.</param>
        /// <returns>A List of ClassRoom objects containing information about classrooms.</returns>
        public List<ClassRoom> LoadClassRooms(SqlConnection currentConnection)
        {
            listClassroom = new List<ClassRoom>();
            query = "select " +
                "CodigoSalon," +
                "(select Tematica from Tematica_Salones where IdTematica = Salones.Tematica)" +
                ",Capacidad" +
                ",(select Estado from Estado_Salones where IdEstado = Salones.Estado)" +
                ",Softwares " +
                "from Salones";

            _command = new SqlCommand(query,currentConnection);
            _reader = _command.ExecuteReader();



            if (_reader.HasRows)
            {
                while (_reader.Read())
                {
                    listClassroom.Add(new ClassRoom
                        (
                            _reader.GetString(0),
                            _reader.GetString(1),
                            _reader.GetByte(2),
                            _reader.GetString(3),
                            _reader.GetString(4)
                        ));

                }
            }
            else
            {

            }
            return listClassroom;
        }
    }
}
