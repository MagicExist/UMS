using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Models.UsersModels;

namespace UMS.Models.ModelsDB
{
    internal class RequestDB
    {
        enum userType
        {
            Admin = 1,
            Professor = 2,
            Student = 3
        }

        private SqlCommand _command;
        private SqlDataReader _reader;
        private ObservableCollection<Request> _listRequest;
        private string query;
        private string userRequestType;

        /// <summary>
        /// Retrieves a collection of requests based on the user's type and ID.
        /// </summary>
        /// <param name="currentConnection">The SqlConnection object representing the database connection.</param>
        /// <param name="currentUser">The User object representing the current user.</param>
        /// <param name="currentUserType">The type of the current user.</param>
        /// <returns>An ObservableCollection of Request objects.</returns>
        public ObservableCollection<Request> loadRequest(SqlConnection currentConnection, User currentUser,int currentUserType)
        {
            _listRequest = new ObservableCollection<Request>();

            switch ((userType)currentUserType) 
            {
                case userType.Student:
                    query = "select " +
                        "(select Nombre from Administradores where Documento = Peticiones.Id_Administrador) as NameAdmin," +
                        "(select Tipo from Usuarios where Id = Peticiones.Id_Usuarios) as TipoUsuario," +
                        "*" +
                        " from Peticiones " +
                        "where Id_Usuarios = @IdCurrentUser";
                    break;
                case userType.Professor:
                    query = "select " +
                        "(select Nombre from Administradores where Documento = Peticiones.Id_Administrador) as NameAdmin," +
                        "(select Tipo from Usuarios where Id = Peticiones.Id_Usuarios) as TipoUsuario," +
                        "*" +
                        " from Peticiones " +
                        "where Id_Usuarios = @IdCurrentUser";
                    break;
                case userType.Admin:
                    query = "select " +
                        "(select Nombre from Administradores where Documento = Peticiones.Id_Administrador) as NameAdmin," +
                        "(select Tipo from Usuarios where Id = Peticiones.Id_Usuarios) as TipoUsuario," +
                        "*" +
                        " from Peticiones " +
                        "where Id_Administrador = @IdCurrentUser";
                    break;
            }

            

            _command = new SqlCommand(query, currentConnection);
            _command.Parameters.AddWithValue("@IdCurrentUser", currentUser.Document);
            _reader = _command.ExecuteReader();

            if (_reader.HasRows)
            {
                while (_reader.Read())
                {
                    switch ((userType)_reader.GetByte(1))
                    {
                        case userType.Student:
                            userRequestType = "Estudiante";
                            break;
                        case userType.Professor:
                            userRequestType = "Profesor";
                            break;
                        case userType.Admin:
                            userRequestType = "Admin";
                            break;
                    }

                    _listRequest.Add(new Request
                        (
                            _reader.GetString(0),
                            userRequestType,
                            _reader.GetString(4),
                            _reader.GetString(5),
                            _reader.GetString(6),
                            _reader.GetString(7),
                            _reader.GetDateTime(8).ToString("yyyy-MM-dd"),
                            _reader.GetString(9),
                            _reader.GetInt16(2)
                        ));
                }
            }
            return _listRequest;
        }
    }
}
