using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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


        public int CurrentUserType {  get { return _currentUserType; } set {  _currentUserType = value; } }
        public LoadRequestStore LoadRequestStore { get { return _loadRequestStore; } set { _loadRequestStore = value; } }

        #endregion
        List<Request> requests= new List<Request>();
        public List<Request> Requests
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

		public RelayCommand newRequest { get; set; }
		public RelayCommand cancelRequest { get; set; }
		public RelayCommand sendRequest { get; set; }
        

        public UserSupportVM()
		{
			NewRequestVisibility= Visibility.Collapsed;
			newRequest = new RelayCommand(MakeRequest);
			cancelRequest = new RelayCommand(CancelRequest);
			sendRequest = new RelayCommand(SendRequest);
        }

		public void OnLoadRequestSub(User currentUser,int currentUserType) 
		{
            #region LoadScheduler
            OpenDbConnection openDbConnection = new OpenDbConnection();
            RequestDB requestDB = new RequestDB();
            SqlConnection currentConnection = openDbConnection.openConnection();
            requests = requestDB.loadRequest(currentConnection, currentUser, currentUserType);
            #endregion
        }


        private void MakeRequest(object parameter) 
		{ 
			ListRequestVisibility= Visibility.Collapsed;
			NewRequestVisibility= Visibility.Visible;
		}

        private void CancelRequest(object parameter)
        {
            ListRequestVisibility = Visibility.Visible;
            NewRequestVisibility = Visibility.Collapsed;
        }

        private void SendRequest(object parameter)
        {

            // The register is saved to the database and the list of requests is updated.

            ListRequestVisibility = Visibility.Visible;
            NewRequestVisibility = Visibility.Collapsed;
        }


    }
}
