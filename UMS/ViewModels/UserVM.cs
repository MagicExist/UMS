using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UMS.Core;
using UMS.Models.UsersModels;

namespace UMS.ViewModels
{
    internal class UserVM : ObservableObjects
    {
        #region variables for logic management
        enum userType
        {
            Admin = 1,
            Professor = 2,
            Student = 3
        }

        private UserSupportVM _userSupportVM;
        private userHomeVM _userHomeVM;
        private AdminHomeVM _adminHomeVM;
        private SearchClassRoomVM _searchClassRoomVM;
        private int _currentUserType;

        public UserSupportVM UserSupportVM {get { return _userSupportVM;} set { _userSupportVM = value; } }
        public userHomeVM UserHomeVM { get { return _userHomeVM; } set { _userHomeVM = value; } }
        public AdminHomeVM AdminHomeVM { get { return _adminHomeVM; } set { _adminHomeVM = value; } }
        public SearchClassRoomVM SearchClassRoomVM { get { return _searchClassRoomVM; } set { _searchClassRoomVM = value; } }
        public int CurrentUserType { get { return _currentUserType; } set { _currentUserType = value; } }

        #endregion

        #region variables for interface management
        private object _currentChildren;
        private Visibility _supportVisibility;
        private Visibility _searchVisibility;

        public Visibility SupportVisibility
        {
            get { return _supportVisibility; }
            set { _supportVisibility = value; OnpropertyChanged(); }
        }

        public Visibility SearchVisibility
        {
            get { return _searchVisibility; }
            set { _searchVisibility = value; OnpropertyChanged(); }
        }

        public object CurrentChildren
        {
            get { return _currentChildren; }
            set { _currentChildren = value; OnpropertyChanged(); }
        }
        #endregion

        #region commands
        public RelayCommand HomeNavCommand { get; set; }
        public RelayCommand UserSupportNavCommand { get; set; }
        public RelayCommand SearchClassRoomNavCommand { get; set; }

        #endregion


        public UserVM()
        {
            HomeNavCommand = new RelayCommand(HomeNavMethod);
            UserSupportNavCommand = new RelayCommand(UserSupportNavMethod);
            SearchClassRoomNavCommand = new RelayCommand(SearchClassRoomNavMethod);
        }

        #region Execute Methods
        public void ViewNavCollapse() 
        {
            SearchVisibility = Visibility.Collapsed;
        }
        public void AdminViewNavCollapse() 
        {
            SupportVisibility = Visibility.Collapsed;
        }

        public void HomeNavMethod(object parameter) 
        {
            switch ((userType)CurrentUserType) 
            {
                case userType.Student:
                    CurrentChildren = UserHomeVM;
                    break;
                case userType.Professor:
                    CurrentChildren = UserHomeVM;
                    break;
                case userType.Admin:
                    CurrentChildren = AdminHomeVM;
                    break;
            }
        }

        public void UserSupportNavMethod(object parameter)
        {
            switch ((userType)CurrentUserType)
            {
                case userType.Student:
                    CurrentChildren = UserSupportVM;
                    break;
                case userType.Professor:
                    CurrentChildren = UserSupportVM;
                    break;
            }
        }

        public void SearchClassRoomNavMethod(object parameter)
        {
            CurrentChildren = SearchClassRoomVM;
        }

        #endregion
    }
}
