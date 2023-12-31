﻿using Microsoft.Data.SqlClient;
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
        enum userType
        {
            Admin = 1,
            Professor = 2,
            Student = 3
        }
        private User _currentUser;
        private string _studentName;
        private string _userType;
        private int _tempUserType;
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

        public int TempUserType { get {return _tempUserType;} set{ _tempUserType = value; UserType = ""; } }

        public string UserType 
        {
            get { return _userType;}
            set 
            {
                switch ((userType)_tempUserType)
                {
                    case userType.Student:
                        _userType = "Estudiante";
                        break;
                    case userType.Professor:
                        _userType = "Profesor";
                        break;
                }
            }
        }
            
        public string StudentName { get { return _studentName; } set { _studentName = value; OnpropertyChanged(); } }

        #endregion

        #region variables for interface management

        // List storing a user's schedule
        List<Class> _scheduler = new List<Class>();
        public List<Class> Scheduler
        {
            get { return _scheduler; }
            set { _scheduler = value; OnpropertyChanged(); }
        }

        // Variables for manipulating the visibility of the controllers in the view 
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

        // variable to store the new details
        private string _details;
        public string Details
        {
            get { return _details; }
            set { _details = value; OnpropertyChanged(); }
        }

        // Variable to control the reading of details
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

        /// <summary>
        /// Collapses visibility properties and sets TextBoxReadOnly to true for student view details mode.
        /// </summary>
        public void studentViewDetailsCollapse() 
        {
            EditDetailsVisibility = Visibility.Collapsed;
            ConfirmDetailsVisibility = Visibility.Collapsed;
            CancelDetailsVisibility = Visibility.Collapsed;
            TextBoxReadOnly = true;
        }

        /// <summary>
        /// Configures visibility properties and sets TextBoxReadOnly to false for professor view details mode.
        /// </summary>
        public void professorViewDetailsCollapse()
        {
            EditDetailsVisibility = Visibility.Visible;
            ConfirmDetailsVisibility = Visibility.Collapsed;
            CancelDetailsVisibility = Visibility.Collapsed;
            TextBoxReadOnly = false;
        }

        /// <summary>
        /// Loads classes into the scheduler based on the current user and user type.
        /// </summary>
        /// <param name="currentUser">The user currently in the program</param>
        public void loadEscheduler(User currentUser) 
        {
            #region LoadScheduler
            OpenDbConnection openDbConnection = new OpenDbConnection();
            ClassDB classDB = new ClassDB();
            SqlConnection currentConnection = openDbConnection.openConnection();
            _scheduler = classDB.loadClass(currentConnection,currentUser,TempUserType);
            #endregion
        }

        /// <summary>
        /// Enters edit mode for the details, allowing changes.
        /// Hides the "Edit" button and shows the "Confirm" and "Cancel" buttons.
        /// </summary>
        /// <param name="parameter">Optional parameter that can be used to pass additional information from the view.</param>
        public void EditDetails(object parameter) 
        {
            TextBoxReadOnly = false;
            EditDetailsVisibility = Visibility.Collapsed;
            ConfirmDetailsVisibility = Visibility.Visible;
            CancelDetailsVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Confirms the edited details, sends the new information to the database, and updates the display.
        /// Hides the "Confirm" and "Cancel" buttons and shows the "Edit" button.
        /// </summary>
        /// <param name="parameter">Optional parameter that can be used to pass additional information from the view.</param>
        public void ConfirmDetails(object parameter)
        {
            // send the new details information to the database and update the text of the details in the texbox

            TextBoxReadOnly = true;
            ConfirmDetailsVisibility = Visibility.Collapsed;
            CancelDetailsVisibility = Visibility.Collapsed;
            EditDetailsVisibility = Visibility.Visible;

        }

        /// <summary>
        /// Cancels the edit operation, discards changes, and reverts to read-only mode.
        /// Hides the "Confirm" and "Cancel" buttons and shows the "Edit" button.
        /// </summary>
        /// <param name="parameter">Optional parameter that can be used to pass additional information from the view.</param>
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
