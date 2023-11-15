using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UMS.Core;
using UMS.Models;
using UMS.Models.ModelsDB;
using UMS.Models.UsersModels;
using UMS.Stores;

namespace UMS.ViewModels
{
    internal class UserSupportVM : ObservableObjects
    {
        #region variables for logic management
        private int _currentUserType;
        private LoadRequestStore _loadRequestStore;
        private User _currentUser;

        public User CurrentUser {  get { return _currentUser; } set { _currentUser = value; } }
        public int CurrentUserType { get { return _currentUserType; } set { _currentUserType = value; } }
        public LoadRequestStore LoadRequestStore { get { return _loadRequestStore; } set { _loadRequestStore = value; } }

        #endregion

        #region variables for interface management
        private string _txtBoxSubject;
        private string _txtBoxDetails;
        private string _txtBoxCurrentDocument;

        public string TxtBoxCurrentDocument
        {
            get { return _txtBoxCurrentDocument; }
            set { _txtBoxCurrentDocument = value; OnpropertyChanged(); }
        }

        public string TxtBoxSubject 
        {
            get {return _txtBoxSubject;}
            set { _txtBoxSubject = value; OnpropertyChanged(); }
        }

        public string TxtBoxDetails
        {
            get { return _txtBoxDetails; }
            set { _txtBoxDetails = value; OnpropertyChanged(); }
        }


        // List for storing user requests
        ObservableCollection<Request> requests= new ObservableCollection<Request>();
        public ObservableCollection<Request> Requests
		{
			get
			{
				return requests;
			}
			set 
			{
				requests = value;
				OnpropertyChanged();
			} 
		}

        // Variables for manipulating the visibility of the controllers in the view 
        private Visibility _listRequestVisibility;
		public Visibility ListRequestVisibility
        {
			get { return _listRequestVisibility; }
			set 
			{
                _listRequestVisibility = value;
				OnpropertyChanged();
			}
		}

		private Visibility _newRequestVisibility;
		public Visibility NewRequestVisibility
		{
			get { return _newRequestVisibility; }
			set 
			{
                _newRequestVisibility = value; 
				OnpropertyChanged();
			}
		}

        #endregion

        #region Commands
        public RelayCommand newRequest { get; set; }
		public RelayCommand cancelRequest { get; set; }
		public RelayCommand sendRequest { get; set; }

        #endregion


        public UserSupportVM()
		{
			NewRequestVisibility= Visibility.Collapsed;
			newRequest = new RelayCommand(MakeRequest);
			cancelRequest = new RelayCommand(CancelRequest);
			sendRequest = new RelayCommand(SendRequest);


        }

        #region Execute Methods

        public void OnLoadRequestSub(User currentUser,int currentUserType) 
		{
            #region LoadScheduler
            OpenDbConnection openDbConnection = new OpenDbConnection();
            RequestDB requestDB = new RequestDB();
            SqlConnection currentConnection = openDbConnection.openConnection();
            requests = requestDB.loadRequest(currentConnection, currentUser, currentUserType);
            #endregion
        }

        /// <summary>
        /// Hides the list of requests and displays the interface for a new request.
        /// </summary>
        /// <param name="parameter">Optional parameter that can be used to pass additional information from the view.</param>
        private void MakeRequest(object parameter) 
		{ 
			ListRequestVisibility= Visibility.Collapsed;
			NewRequestVisibility= Visibility.Visible;
		}

        /// <summary>
        /// Displays the list of requests and hides the interface for a new request.
        /// </summary>
        /// <param name="parameter">Optional parameter that can be used to pass additional information from the view.</param>
        private void CancelRequest(object parameter)
        {
            ListRequestVisibility = Visibility.Visible;
            NewRequestVisibility = Visibility.Collapsed;
        }

        /// <summary>
        /// The request is saved to the database, and the list of requests is updated.
        /// Displays the list of requests and hides the interface for a new request.
        /// </summary>
        /// <param name="parameter">Optional parameter that can be used to pass additional information from the view.</param>
        private void SendRequest(object parameter)
        {

            // The register is saved to the database and the list of requests is updated.
            

            ListRequestVisibility = Visibility.Visible;
            NewRequestVisibility = Visibility.Collapsed;
        }

        #endregion

    }
}
