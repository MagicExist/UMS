using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private SqlCommand _command;
        private SqlDataReader _reader;
        private List<Class> _listClass;

        private string day;



        public List<Class> loadClass(SqlConnection currentConnection) 
        {
            _listClass = new List<Class>();
            string query = 
                "select " +
                "Dia," +
                "CONVERT(time,Hora_Inicio) as hora_inicio," +
                "CONVERT(time,Hora_Final) as hora_final," +
                "Id_Grupo," +
                "Codigo_Salon," +
                "(select Nombre from Asignaturas where Codigo = Clases.Codigo_Asignatura) as asignatura " +
                "from Clases";

            _command = new SqlCommand(query,currentConnection);
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
                            _reader.GetInt16(3).ToString(),
                            _reader.GetString(4),
                            _reader.GetString(5)
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
