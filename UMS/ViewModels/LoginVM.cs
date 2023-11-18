using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Core;
using UMS.Models.ModelsDB;
using UMS.Models.UsersModels;
using UMS.Stores;

namespace UMS.ViewModels
{
    internal class LoginVM : ObservableObjects
    {
        private string _txtBoxUser;
        private string _txtBoxPassword;
        private string _labelError;

        private LoginStore _loginStore;
        private LoadRequestStore _loadRequestStore;
        private UserVM _userVM;
        private UserSupportVM _userSupportVM;
        private userHomeVM _userHomeVM;
        private AdminHomeVM _adminHomeVM;
        private SearchClassRoomVM _searchClassRoomVM;

        public RelayCommand AllowAccess { get; set; }

        enum userType 
        {
            Admin = 1,
            Professor = 2,
            Student = 3
        }

        public string TxtBoxUser
        {
            get { return _txtBoxUser; }
            set { _txtBoxUser = value; OnpropertyChanged(); }
        }

        public string TxtBoxPassword
        {
            get { return _txtBoxPassword; }
            set { _txtBoxPassword = value; OnpropertyChanged(); }
        }

        public string LabelError 
        {
            get { return _labelError; }
            set { _labelError = value; OnpropertyChanged(); }
        }

        internal LoginStore LoginStore { get => _loginStore; set => _loginStore = value; }
        internal UserVM UserVM { get => _userVM; set => _userVM = value; }
        internal UserSupportVM UserSupportVM { get => _userSupportVM; set => _userSupportVM = value; }
        internal userHomeVM UserHomeVM { get => _userHomeVM; set => _userHomeVM = value; }
        internal AdminHomeVM AdminHomeVM { get => _adminHomeVM; set => _adminHomeVM = value; }
        internal SearchClassRoomVM SearchClassRoomVM { get => _searchClassRoomVM; set => _searchClassRoomVM = value; }
        internal LoadRequestStore LoadRequestStore { get {  return _loadRequestStore; } set { _loadRequestStore = value; } }

        /// <summary>
        /// This method controls the login of all users in the application
        /// </summary>
        /// <param name="parameter">An optional parameter.</param>
        public void AllowMethod(object parameter)
        {
            // Check if the username and password fields are not null and not empty
            if ((TxtBoxUser != null && TxtBoxPassword != null) && (TxtBoxUser != string.Empty && TxtBoxPassword != string.Empty)) 
            {
                try 
                {
                    // Initialize database-related objects
                    OpenDbConnection openDbConnection = new OpenDbConnection();
                    LoginDB loginDB = new LoginDB();
                    DaysDB daysDB = new DaysDB();
                    ClassRoomTopicsDB topicsDB = new ClassRoomTopicsDB();
                    ClassRoomStatesDB statesDB = new ClassRoomStatesDB();
                    ClassRoomBlockDB blockDB = new ClassRoomBlockDB();

                    SqlConnection currentConnection = openDbConnection.openConnection();
                    (User currentUser, int type) = loginDB.allowLogin(currentConnection, TxtBoxUser, TxtBoxPassword);

                    // Switch based on the user type
                    switch ((userType)type)
                    {
                        case userType.Student:
                            UserHomeVM.studentViewDetailsCollapse();
                            UserHomeVM.TempUserType = type;
                            UserHomeVM.CurrentUser = currentUser;

                            UserSupportVM.CurrentUser = currentUser;
                            UserSupportVM.TxtBoxCurrentDocument = currentUser.Document;

                            UserVM.CurrentChildren = UserHomeVM;
                            UserVM.CurrentUserType = type;
                            UserVM.CurrentUser = currentUser;
                            UserVM.ViewNavCollapse();

                            LoginStore.OnLoginAllowInvoke(UserVM, currentUser);
                            break;
                        case userType.Professor:
                            UserHomeVM.professorViewDetailsCollapse();
                            UserHomeVM.TempUserType = type;
                            UserHomeVM.CurrentUser = currentUser;

                            UserSupportVM.CurrentUser = currentUser;
                            UserSupportVM.TxtBoxCurrentDocument = currentUser.Document;

                            UserVM.CurrentChildren = UserHomeVM;
                            UserVM.CurrentUserType = type;
                            UserVM.CurrentUser = currentUser;
                            UserVM.ViewNavCollapse();

                            LoginStore.OnLoginAllowInvoke(UserVM, currentUser);
                            break;
                        case userType.Admin:
                            AdminHomeVM.CurrentUser = currentUser;
                            AdminHomeVM.CurrentUserType = type;

                            SearchClassRoomVM.Days = daysDB.GetDays(currentConnection);
                            SearchClassRoomVM.Topics = topicsDB.GetTopics(currentConnection);
                            SearchClassRoomVM.States = statesDB.GetStates(currentConnection);
                            SearchClassRoomVM.Blocks = blockDB.GetBlocks(currentConnection);

                            #region LoadClassrooms
                            ClassRoomsDB classRoomsDB = new ClassRoomsDB();
                            SearchClassRoomVM.ClassRooms = classRoomsDB.LoadClassRooms(currentConnection);
                            #endregion

                            UserVM.CurrentChildren = AdminHomeVM;
                            UserVM.CurrentUserType = type;
                            UserVM.CurrentUser = currentUser;
                            UserVM.AdminViewNavCollapse();

                            LoadRequestStore.OnLoadRequestInvoke(currentUser,type);
                            LoginStore.OnLoginAllowInvoke(UserVM, currentUser);
                            break;
                    }
                    currentConnection.Close();
                }
                catch (NullReferenceException ex)
                {
                    LabelError = ex.Message;
                }
                catch (Exception ex)
                {
                    LabelError = "Error inesperado";
                }
            }
            else 
            {
                LabelError = "Los campos no pueden estar vacios";
            }
        }
        public LoginVM()
        {
            AllowAccess = new RelayCommand(AllowMethod);
        }
    }
}
