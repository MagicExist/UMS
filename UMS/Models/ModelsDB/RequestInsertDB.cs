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
