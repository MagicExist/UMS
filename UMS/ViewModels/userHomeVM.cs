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
    class userHomeVM : ObservableObjects
    {
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

            ConfirmDetailsVisibility = Visibility.Collapsed;
            CancelDetailsVisibility = Visibility.Collapsed;
            TextBoxReadOnly = true;

            editDetailsCommand = new RelayCommand(EditDetails);
            confirmDetailsCommand = new RelayCommand(ConfirmDetails);
            canceltDetailsCommand = new RelayCommand(CancelDetails);

            _scheduler.Add(new Class("Lunes", "10:00", "12:00", "052", "6-405", "Calculo integral", "Hoy vamos a ver Integrales Impripias de primera especie, tambien abarcaremos el tema de sucesiones monotonas, acotadas, aritmeticas y geometricas."));
            _scheduler.Add(new Class("Lunes", "10:00", "12:00", "031", "12-302", "Calculo diferencial", "detalles 2"));
            _scheduler.Add(new Class("Lunes", "10:00", "12:00", "032", "1-108", "Base de datos", "detalles 3"));
            _scheduler.Add(new Class("Lunes", "10:00", "12:00", "064", "3-203", "Herramientas de programacion", "detalles 4"));
            _scheduler.Add(new Class("Lunes", "10:00", "12:00", "054", "5-101", "Ingles I", "detalles 5"));
            _scheduler.Add(new Class("Martes", "10:00", "12:00", "012", "2-103", "Ingles II", "detalles 6"));
            _scheduler.Add(new Class("Martes", "10:00", "12:00", "028", "13-102", "Ingenieria del software", "detalles 7"));

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
