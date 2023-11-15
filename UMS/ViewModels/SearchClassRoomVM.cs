using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UMS.Core;
using UMS.Models;

namespace UMS.ViewModels
{
    class SearchClassRoomVM : ObservableObjects
    {
        #region variables for interface management

        // Lists for comboBoxes 
        List<string> days = new List<string>();
        public List<string> Days { get => days; set => days = value; }

        List<string> topics = new List<string>();
        public List<string> Topics { get => topics; set => topics = value; }

        List<string> states = new List<string>();
        public List<string> States { get => states; set => states = value; }

        List<string> blocks = new List<string>();
        public List<string> Blocks { get => blocks; set => blocks = value; }

        List<string> hours = new List<string> {"6:00", "7:00", "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00" };
        public List<string> Hours { get => hours; }


        // List to store classrooms
        List<ClassRoom> _classRooms = new List<ClassRoom>();
        public List<ClassRoom> ClassRooms 
        {
            get { return _classRooms; }
            set { _classRooms = value; OnpropertyChanged(); }
        }

        // Variable to control the visibility of the advanced search in the view.
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

            _classRooms.Add(new ClassRoom("13-204", "Basica", 20, "Libre", "Visual studio"));
            _classRooms.Add(new ClassRoom("13-208", "Basica", 20, "Ocupado", "Visual studio, SQL Server, MongoDB, Redis, Visual studio code, AutoCad, Rstudio, Pseint"));
            _classRooms.Add(new ClassRoom("1-102", "Basica", 15, "Ocupado", "proteus"));
            _classRooms.Add(new ClassRoom("6-205", "Basica", 35, "Libre", "No tiene"));
            _classRooms.Add(new ClassRoom("13-204", "Basica", 20, "Ocupado", "Visual studio"));
            _classRooms.Add(new ClassRoom("1-102", "Basica", 15, "Libre", "proteus"));
            _classRooms.Add(new ClassRoom("13-208", "Basica", 20, "Ocupado", "Visual studio, SQL Server, MongoDB, Redis, Visual studio code"));
            _classRooms.Add(new ClassRoom("6-205", "Basica", 35, "Libre", "No tiene"));
            _classRooms.Add(new ClassRoom("13-208", "Basica", 20, "Ocupado", "Visual studio, SQL Server, MongoDB, Redis, Visual studio code"));


        }

        #region Execute Methods

        /// <summary>
        /// Toggles the visibility of the advanced search interface.
        /// If the advanced search interface is collapsed, it is made visible; otherwise, it is collapsed.
        /// </summary>
        /// <param name="parameter">Optional parameter that can be used to pass additional information from the view.</param>
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
