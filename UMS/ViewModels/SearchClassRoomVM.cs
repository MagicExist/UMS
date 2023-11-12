using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UMS.Core;

namespace UMS.ViewModels
{
    class SearchClassRoomVM : ObservableObjects
    {
        #region variables for interface management
        private Visibility _advancedSearchVisibility;

        public Visibility AdvancedSearchVisibility 
        {
            get { return _advancedSearchVisibility; }
            set 
            { _advancedSearchVisibility = value; OnpropertyChanged(); } 
        }

        #endregion

        #region commands
        public RelayCommand AdvancedSearchCommand { get; set; }

        #endregion

        public SearchClassRoomVM()
        {
            AdvancedSearchVisibility = Visibility.Collapsed;
            AdvancedSearchCommand = new RelayCommand(ShowAdvancedSearch);

        }

        #region Execute Methods

        /// <summary>
        /// This method is used to show or hide the advanced search section.
        /// </summary>
        /// <param name="parameter"></param>
        public void ShowAdvancedSearch(object parameter) 
        {
            if (AdvancedSearchVisibility == Visibility.Collapsed)
            {
                AdvancedSearchVisibility= Visibility.Visible;
            }
            else 
            { 
                AdvancedSearchVisibility= Visibility.Collapsed;
            }
        }

        #endregion


    }
}
