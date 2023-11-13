using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using UMS.Core;
using UMS.Models;
using UMS.Models.ModelsDB;
using UMS.Models.UsersModels;

namespace UMS.ViewModels
{
    class userHomeVM : ObservableObjects
    {
        #region variables for logic management
        private User _currentUser;
        private string _studentName;
        public User CurrentUser 
        {
            get { return _currentUser; }
            set 
            {
                _currentUser = value;
                StudentName = _currentUser.Name;
                loadEscheduler(_currentUser);
            }
        }
            
        public string StudentName { get { return _studentName; } set { _studentName = value;OnpropertyChanged(); } }

        #endregion


        #region variables for interface management
        List<Class> _scheduler = new List<Class>();
        public List<Class> Scheduler
        {
            get { return _scheduler; }
            set { _scheduler = value; OnpropertyChanged(); }
        }

        Visibility _editDetailsVisibility;
        public Visibility EditDetailsVisibility 
        {
            get { return _editDetailsVisibility; } 
            set { _editDetailsVisibility = value; OnpropertyChanged(); } 
        }

        Visibility _confirmDetailsVisibility;
        public Visibility ConfirmDetailsVisibility
        {
            get{ return _confirmDetailsVisibility; }
            set { _confirmDetailsVisibility = value; OnpropertyChanged(); }
        }

        Visibility _cancelDetailsVisibility;
        public Visibility CancelDetailsVisibility
        {
            get{ return _cancelDetailsVisibility; }
            set { _cancelDetailsVisibility = value; OnpropertyChanged(); }
        }

        private string _details;
        public string Details
        {
            get { return _details; }
            set { _details = value; OnpropertyChanged(); }
        }

        private bool _textBoxReadOnly;

        public bool TextBoxReadOnly
        {
            get { return _textBoxReadOnly; }
            set { _textBoxReadOnly = value; OnpropertyChanged(); }
        }

        Class _selectClass;
        public Class SelectClass { get => _selectClass; set => _selectClass = value as Class; }

        #endregion

        #region Commands

        public RelayCommand editDetailsCommand { get; set; }
        public RelayCommand confirmDetailsCommand { get; set; }
        public RelayCommand canceltDetailsCommand { get; set; }


        #endregion


        public userHomeVM()
        {

            

            editDetailsCommand = new RelayCommand(EditDetails);
            confirmDetailsCommand = new RelayCommand(ConfirmDetails);
            canceltDetailsCommand = new RelayCommand(CancelDetails);

            
        }

        #region Execute Methods

        public void studentViewDetailsCollapse() 
        {
            EditDetailsVisibility = Visibility.Collapsed;
            ConfirmDetailsVisibility = Visibility.Collapsed;
            CancelDetailsVisibility = Visibility.Collapsed;
            TextBoxReadOnly = true;
        }

        public void loadEscheduler(User currentUser) 
        {
            #region LoadScheduler
            OpenDbConnection openDbConnection = new OpenDbConnection();
            ClassDB classDB = new ClassDB();
            SqlConnection currentConnection = openDbConnection.openConnection();
            _scheduler = classDB.loadClass(currentConnection,currentUser);
            #endregion
        }

        public void EditDetails(object parameter) 
        {
            TextBoxReadOnly = false;
            EditDetailsVisibility = Visibility.Collapsed;
            ConfirmDetailsVisibility = Visibility.Visible;
            CancelDetailsVisibility = Visibility.Visible;
        }

        public void ConfirmDetails(object parameter)
        {
            // send the new details information to the database and update the text of the details in the texbox

            TextBoxReadOnly = true;
            ConfirmDetailsVisibility = Visibility.Collapsed;
            CancelDetailsVisibility = Visibility.Collapsed;
            EditDetailsVisibility = Visibility.Visible;

        }

        public void CancelDetails(object parameter)
        {
            TextBoxReadOnly = true;
            ConfirmDetailsVisibility = Visibility.Collapsed;
            CancelDetailsVisibility = Visibility.Collapsed;
            EditDetailsVisibility = Visibility.Visible;
        }

        #endregion

    }
}
