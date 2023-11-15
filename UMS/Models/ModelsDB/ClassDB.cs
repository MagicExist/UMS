using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Models.UsersModels;

namespace UMS.Models.ModelsDB
{
    class ClassDB
    {
        enum Days
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6
        }
        enum userType
        {
            Admin = 1,
            Professor = 2,
            Student = 3
        }

        private SqlCommand _command;
        private SqlDataReader _reader;
        private List<Class> _listClass;
        private string query;

        private string day;


        /// <summary>
        /// Retrieves a list of classes from the database using the specified SqlConnection.
        /// </summary>
        /// <param name="currentConnection">The SqlConnection object for database interaction.</param>
        /// <returns>
        /// A List of <see cref="Class"/> objects representing the classes retrieved from the database.
        /// </returns>
        public List<Class> loadClass(SqlConnection currentConnection,User currentUser,int currentUserType) 
        {
            _listClass = new List<Class>();


            switch ((userType)currentUserType)
            {
                case userType.Student:
                    query = 
                        "select " +
                        "Dia," +
                        "CONVERT(time,Hora_Inicio) as hora_inicio," +
                        "CONVERT(time,Hora_Final) as hora_final," +
                        "Id_Grupo," +
                        "Codigo_Salon," +
                        "(select Nombre from Asignaturas where Codigo = Clases.Codigo_Asignatura) as asignatura, " +
                        "Detalles," +
                        "Id " +
                        "from Clases " +
                        "where Id_Grupo in (select IdGrupo from GruposEstudiantes where IdEstudiante = @IdCurrentUser)";
                    break;
                case userType.Professor:
                    query = "select " +
                        "Dia," +
                        "CONVERT(time,Hora_Inicio) as hora_inicio," +
                        "CONVERT(time,Hora_Final) as hora_final," +
                        "Id_Grupo," +
                        "Codigo_Salon," +
                        "(select Nombre from Asignaturas where Codigo = Clases.Codigo_Asignatura) as asignatura, " +
                        "Detalles," +
                        "Id " +
                        "from Clases " +
                        "where Id_Grupo in (select IdGrupo from Grupos where IdProfesor = @IdCurrentUser)";
                    break;
            }

            _command = new SqlCommand(query,currentConnection);
            _command.Parameters.AddWithValue("@IdCurrentUser",currentUser.Document);
            _reader = _command.ExecuteReader();
            if (_reader.HasRows) 
            {
                while (_reader.Read()) 
                {
                    switch ((Days)_reader.GetByte(0))
                    {
                        case Days.Monday:
                            day = "Lunes";
                            break;
                        case Days.Tuesday:
                            day = "Martes";
                            break;
                        case Days.Wednesday:
                            day = "Miercoles";
                            break;
                        case Days.Thursday:
                            day = "Jueves";
                            break;
                        case Days.Friday:
                            day = "Viernes";
                            break;
                        case Days.Saturday:
                            day = "Sabado";
                            break;
                    }

                    _listClass.Add(new Class
                        (
                            day,
                            _reader.GetTimeSpan(1).ToString(@"hh\:mm"),
                            _reader.GetTimeSpan(2).ToString(@"hh\:mm"),
                            _reader.GetString(3),
                            _reader.GetString(4),
                            _reader.GetString(5),
                            _reader.GetString(6),
                            _reader.GetInt32(7)
                        ));
                }
            }
            else 
            {

            }
            return _listClass;
        }
    }
}
