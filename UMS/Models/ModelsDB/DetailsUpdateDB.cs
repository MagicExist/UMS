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
    internal class DetailsUpdateDB
    {
        private SqlCommand _command;
        private SqlDataReader _reader;
        private string query;

        public void InsertDetail(SqlConnection currentConnection, Class currentRequest)
        {
                query = "update Clases set Detalles = @currentDetail where Id = @currentId";
                _command = new SqlCommand(query, currentConnection);
                _command.Parameters.AddWithValue("@currentDetail", currentRequest.Details);
                _command.Parameters.AddWithValue("@currentId", currentRequest.Id);

                _command.ExecuteNonQuery();
        }

    }
}
