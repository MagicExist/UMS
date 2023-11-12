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


            _classRooms.Add(new ClassRoom("13-204", "Basica", 20, "Visual studio"));
            _classRooms.Add(new ClassRoom("13-208", "Basica", 20, "Visual studio, SQL Server, MongoDB, Redis, Visual studio code, AutoCad, Rstudio, Pseint"));
            _classRooms.Add(new ClassRoom("1-102", "Basica", 15, "proteus"));
            _classRooms.Add(new ClassRoom("6-205", "Basica", 35, "No tiene"));
            _classRooms.Add(new ClassRoom("13-204", "Basica", 20, "Visual studio"));
            _classRooms.Add(new ClassRoom("1-102", "Basica", 15, "proteus"));
            _classRooms.Add(new ClassRoom("13-208", "Basica", 20, "Visual studio, SQL Server, MongoDB, Redis, Visual studio code"));
            _classRooms.Add(new ClassRoom("6-205", "Basica", 35, "No tiene"));
            _classRooms.Add(new ClassRoom("13-208", "Basica", 20, "Visual studio, SQL Server, MongoDB, Redis, Visual studio code"));
            _classRooms.Add(new ClassRoom("13-204", "Basica", 20, "Visual studio"));
            _classRooms.Add(new ClassRoom("1-102", "Basica", 15, "proteus"));
            _classRooms.Add(new ClassRoom("6-205", "Basica", 35, "No tiene"));
            _classRooms.Add(new ClassRoom("13-204", "Basica", 20, "Visual studio"));
            _classRooms.Add(new ClassRoom("1-102", "Basica", 15, "proteus"));
            _classRooms.Add(new ClassRoom("6-205", "Basica", 35, "No tiene"));
            _classRooms.Add(new ClassRoom("13-208", "Basica", 20, "Visual studio, SQL Server, MongoDB, Redis, Visual studio code"));


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
