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

        public void InsertRequest(SqlConnection currentConnection, Request currentRequest)
        {
                query = "update Peticiones set Respuesta = @currentRequest where Id = @currentId";
                _command = new SqlCommand(query, currentConnection);
                _command.Parameters.AddWithValue("@currentRequest", currentRequest.Reply);
                _command.Parameters.AddWithValue("@currentId", currentRequest.Id);

                _command.ExecuteNonQuery();
        }

    }
}
