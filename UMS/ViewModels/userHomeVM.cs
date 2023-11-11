using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UMS.Core;
using UMS.Models;
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
            }
        }
            
        public string StudentName { get { return _studentName; } set { _studentName = value;OnpropertyChanged(); } }

        #endregion


        #region variables for interface management
        List<Class> horario = new List<Class>();
        public List<Class> Scheduler
        {
            get { return horario; }
            set { horario = value; OnpropertyChanged(); }
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

        #endregion

        #region Commands

        public RelayCommand editDetailsCommand { get; set; }
        public RelayCommand confirmDetailsCommand { get; set; }
        public RelayCommand canceltDetailsCommand { get; set; }

        #endregion



        public userHomeVM()
        {

            ConfirmDetailsVisibility= Visibility.Collapsed;
            CancelDetailsVisibility= Visibility.Collapsed;
            Details = "Hoy vamos a ver Integrales Impripias de primera especie, tambien abarcaremos el tema de sucesiones monotonas, acotadas, aritmeticas y geometricas.";
            TextBoxReadOnly = true;

            editDetailsCommand = new RelayCommand(EditDetails);
            confirmDetailsCommand = new RelayCommand(ConfirmDetails);
            canceltDetailsCommand = new RelayCommand(CancelDetails);

            horario.Add(new Class("Lunes", "10:00", "12:00", "052", "6-205", "Calculo diferencial"));
            horario.Add(new Class("Lunes", "10:00", "12:00", "052", "6-205", "Calculo diferencial"));
            horario.Add(new Class("Lunes", "10:00", "12:00", "052", "6-205", "Calculo diferencial"));
            horario.Add(new Class("Lunes", "10:00", "12:00", "052", "6-205", "Calculo diferencial"));
            horario.Add(new Class("Lunes", "10:00", "12:00", "052", "6-205", "Calculo diferencial"));
            horario.Add(new Class("Martes", "10:00", "12:00", "052", "6-205", "Calculo diferencial"));
            horario.Add(new Class("Martes", "10:00", "12:00", "052", "6-205", "Calculo diferencial"));
            horario.Add(new Class("Miercoles", "10:00", "12:00", "052", "6-205", "Calculo diferencial"));
            horario.Add(new Class("Miercoles", "10:00", "12:00", "052", "6-205", "Calculo diferencial"));
            horario.Add(new Class("Miercoles", "10:00", "12:00", "052", "6-205", "Calculo diferencial"));
            horario.Add(new Class("Miercoles", "10:00", "12:00", "052", "6-205", "Calculo diferencial"));
            horario.Add(new Class("Miercoles", "10:00", "12:00", "052", "6-205", "Calculo diferencial"));
            horario.Add(new Class("Lunes", "10:00", "12:00", "052", "6-205", "Calculo diferencial"));
            horario.Add(new Class("Lunes", "10:00", "12:00", "052", "6-205", "Calculo diferencial"));
            horario.Add(new Class("Viernes", "10:00", "12:00", "052", "6-205", "Calculo diferencial"));
            horario.Add(new Class("Viernes", "10:00", "12:00", "052", "6-205", "Calculo diferencial"));
            horario.Add(new Class("Viernes", "10:00", "12:00", "052", "6-205", "Calculo diferencial"));
            horario.Add(new Class("Viernes", "10:00", "12:00", "052", "6-205", "Calculo diferencial"));
            horario.Add(new Class("Viernes", "10:00", "12:00", "052", "6-205", "Calculo diferencial"));
            

        }

        #region Execute Methods

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
