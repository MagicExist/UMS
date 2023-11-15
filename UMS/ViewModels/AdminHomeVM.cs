using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using UMS.Core;
using UMS.Models;
using UMS.Models.ModelsDB;
using UMS.Models.UsersModels;
using UMS.Views;

namespace UMS.ViewModels
{
    internal class AdminHomeVM : ObservableObjects
    {
        #region variables for logic management
        private User _currentUser;
        private string _adminName;
        private int _currentUserType;
      

        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                AdminName = _currentUser.Name;
            }
        }
        

        public int CurrentUserType {get { return _currentUserType; } set { _currentUserType = value; } }
        public string AdminName { get { return _adminName; } set { _adminName = value; OnpropertyChanged(); } }


        #endregion


        #region variables for interface management

        // List for storing requests assigned to administrators
        ObservableCollection<Request> _requests= new ObservableCollection<Request>();
        public ObservableCollection<Request> Requests 
        {
            get { return _requests; }
            set { _requests = value; OnpropertyChanged(); }
        
        }

        // Variables for manipulating the visibility of the controllers in the view 
        Visibility _replyButtonVisibility;
        public Visibility ReplyButtonVisibility
        {
            get { return _replyButtonVisibility; }
            set { _replyButtonVisibility = value; OnpropertyChanged(); }
        }

        Visibility _sendButtonVisibility;
        public Visibility SendButtonVisibility
        {
            get { return _sendButtonVisibility; }
            set { _sendButtonVisibility = value; OnpropertyChanged(); }
        }

        Visibility _cancelButtonVisibility;
        public Visibility CancelButtonVisibility
        {
            get { return _cancelButtonVisibility; }
            set { _cancelButtonVisibility = value; OnpropertyChanged(); }
        }

        Visibility _replyTextBoxVisibility;
        public Visibility ReplyTextBoxVisibility
        {
            get { return _replyTextBoxVisibility; }
            set { _replyTextBoxVisibility = value; OnpropertyChanged(); }
        }

        #endregion

        #region commands

        public RelayCommand ReplyCommand { get; set; }
        public RelayCommand SendRequestCommand { get; set; }
        public RelayCommand CancelReplyCommand { get; set; }
        #endregion

        public AdminHomeVM()
        {


            SendButtonVisibility= Visibility.Collapsed;
            CancelButtonVisibility= Visibility.Collapsed;
            ReplyTextBoxVisibility= Visibility.Collapsed;


            ReplyCommand = new RelayCommand(MakeReply);
            SendRequestCommand = new RelayCommand(SendRequestMethod);
            CancelReplyCommand = new RelayCommand(CancelReply);

        }

        #region execute Methods

        public void SendRequestMethod(object paremeter) 
        {
            #region LoadScheduler
            OpenDbConnection openDbConnection = new OpenDbConnection();
            RequestDB requestDB = new RequestDB();
            SqlConnection currentConnection = openDbConnection.openConnection();
            Requests = requestDB.loadRequest(currentConnection, CurrentUser, CurrentUserType);
            #endregion
        }

        public void OnLoadRequestSub(User currentUser,int currentUserType)
        {
            #region LoadScheduler
            OpenDbConnection openDbConnection = new OpenDbConnection();
            RequestDB requestDB = new RequestDB();
            SqlConnection currentConnection = openDbConnection.openConnection();
            _requests = requestDB.loadRequest(currentConnection, currentUser,currentUserType);
            #endregion
        }

        /// <summary>
        /// Initiates the reply process
        /// </summary>
        /// <param name="parameter">Optional parameter that can be used to pass additional information from the view.</param>
        public void MakeReply(object parameter) 
        {
            ReplyButtonVisibility = Visibility.Collapsed;
            SendButtonVisibility = Visibility.Visible;
            CancelButtonVisibility = Visibility.Visible;
            ReplyTextBoxVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Cancels the reply process, discards changes, and reverts to the initial state.
        /// </summary>
        /// <param name="parameter">Optional parameter that can be used to pass additional information from the view.</param>
        public void CancelReply(object parameter)
        {
            ReplyButtonVisibility = Visibility.Visible;
            SendButtonVisibility = Visibility.Collapsed;
            CancelButtonVisibility = Visibility.Collapsed;
            ReplyTextBoxVisibility = Visibility.Collapsed;
        }

        #endregion 

    }
}
