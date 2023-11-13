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

        List<string> days = new List<string> { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };
        public List<string> Days { get => days; }

        List<string> startHours = new List<string> {"6:00", "7:00", "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00" };
        public List<string> StartHours { get => startHours; }

        List<string> endtHours = new List<string> {"7:00", "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", };
        public List<string> EndHours { get => endtHours; }

        List<ClassRoom> _classRooms = new List<ClassRoom>();
        public List<ClassRoom> ClassRooms 
        {
            get { return _classRooms; }
            set { _classRooms = value; OnpropertyChanged(); }
        }


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
