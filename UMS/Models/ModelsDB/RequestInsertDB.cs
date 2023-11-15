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
    internal class RequestInsertDB
    {
        private SqlCommand _command;
        private SqlDataReader _reader;
        private string query;


        /// <summary>
        /// Inserts a new request into the database.
        /// </summary>
        /// <param name="currentConnection">The SqlConnection object representing the database connection.</param>
        /// <param name="currentRequest">The Request object containing the information for the new request.</param>
        /// <param name="currentUser">The User object representing the user initiating the request.</param>
        public void InsertRequest(SqlConnection currentConnection, Request currentRequest,User currentUser)
        {
                query = "insert into Peticiones (Id_Administrador,Id_Usuarios,Asunto,Descripcion,Estado_Peticion,Fecha,Respuesta)" +
                "values(1025884381,@currentUserId,@currentSubject,@currentDescription,'Pendiente',GetDate(),'');";

                _command = new SqlCommand(query, currentConnection);
                _command.Parameters.AddWithValue("@currentUserId", currentUser.Document);
                _command.Parameters.AddWithValue("@currentSubject", currentRequest.Subject);
            _command.Parameters.AddWithValue("@currentDescription", currentRequest.Details);

            _command.ExecuteNonQuery();
        }

    }
}
