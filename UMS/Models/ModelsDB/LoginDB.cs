using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Configuration;
using UMS.Models.UsersModels;
using Microsoft.Data;
using System.Data;

namespace UMS.Models.ModelsDB
{
    internal class LoginDB
    {
        private SqlCommand _command;
        private SqlDataReader _reader;
        private User _user;
        private int type;


        /// <summary>
        /// Validates user login credentials using the specified SqlConnection.
        /// </summary>
        /// <param name="currentConnection">The SqlConnection object for database interaction.</param>
        /// <param name="email">The email address of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>
        /// A tuple containing a <see cref="User"/> object representing the authenticated user and an <see cref="int"/> representing the user type.
        /// </returns>
        public (User, int) allowLogin(SqlConnection currentConnection, string email, string password)
        {
            _command = new SqlCommand("FiltrarUsuario", currentConnection);
            _command.CommandType = CommandType.StoredProcedure;

            _command.Parameters.AddWithValue("@email", email);
            _command.Parameters.AddWithValue("@password", password);

            _reader = _command.ExecuteReader();
            if (_reader.HasRows)
            {
                while (_reader.Read())
                {
                    _user = new User
                        (
                            _reader.GetString(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(4)
                        );
                }
            }
            else
            {

            }

            _reader.Close();

            

            string query  = "select Tipo from Usuarios where Id = @document";

            _command.CommandText = query;
            _command.CommandType = CommandType.Text;
            _command.Parameters.AddWithValue("@document", _user.Document);

            _reader = _command.ExecuteReader();
            if (_reader.HasRows)
            {
                while (_reader.Read())
                {
                    byte tempType = _reader.GetByte(0);
                    type = Convert.ToInt32(tempType);
                }
            }
            else
            {

            }

            return (_user,type);
        }
    }
}
