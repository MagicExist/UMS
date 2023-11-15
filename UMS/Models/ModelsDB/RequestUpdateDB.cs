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
    internal class RequestUpdateDB
    {
        private SqlCommand _command;
        private SqlDataReader _reader;
        private string query;

        public void UpdateRequest(SqlConnection currentConnection, Request currentRequest)
        {
                query = "update Peticiones set Respuesta = @currentRequest, Estado_Peticion = 'Respondida' where Id = @currentId";
                _command = new SqlCommand(query, currentConnection);
                _command.Parameters.AddWithValue("@currentRequest", currentRequest.Reply);
                _command.Parameters.AddWithValue("@currentId", currentRequest.Id);

                _command.ExecuteNonQuery();
        }

    }
}
