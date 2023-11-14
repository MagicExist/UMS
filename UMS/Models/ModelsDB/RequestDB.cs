using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Models.UsersModels;

namespace UMS.Models.ModelsDB
{
    internal class RequestDB
    {
        private SqlCommand _command;
        private SqlDataReader _reader;
        private List<Request> _listRequest;
   
        public List<Request> loadRequest(SqlConnection currentConnection, User currentUser)
        {
            _listRequest = new List<Request>();
            string query = "select * from Peticiones where Id_Administrador = @IdCurrentUser";

            _command = new SqlCommand(query, currentConnection);
            _command.Parameters.AddWithValue("@IdCurrentUser", currentUser.Document);
            _reader = _command.ExecuteReader();
            if (_reader.HasRows)
            {
                while (_reader.Read())
                {

                    _listRequest.Add(new Request
                        (
                            currentUser.Name,
                            _reader.GetString(3),
                            _reader.GetString(4),
                            _reader.GetString(5),
                            _reader.GetDateTime(6).ToString("yyyy-MM-dd")
                        ));
                }
            }
            else
            {

            }
            return _listRequest;
        }
    }
}
