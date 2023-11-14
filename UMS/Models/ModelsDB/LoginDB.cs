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

        enum userType
        {
            Admin = 1,
            Professor = 2,
            Student = 3
        }

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
                    type = _reader.GetInt32(0);
                    switch ((userType)type)
                    {
                        case userType.Student:
                            _user = new Student
                                    (
                                        _reader.GetString(1),
                                        _reader.GetString(2),
                                        _reader.GetString(3),
                                        _reader.GetString(4)
                                    );
                            break;
                        case userType.Professor:
                            _user = new Professor
                                    (
                                        _reader.GetString(1),
                                        _reader.GetString(2),
                                        _reader.GetInt32(3),
                                        _reader.GetString(4),
                                        _reader.GetString(5),
                                        _reader.GetString(6)
                                    );
                            break;
                    }
                }
                
            }
            else
            {

            }
            _reader.Close();
            return (_user, type);
        }
    }
}
