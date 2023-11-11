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
    internal class AdminHomeVM : ObservableObjects
    {
        #region variables for interface management

        List<Request> _requests= new List<Request>();
        public List<Request> Requests 
        {
            get { return _requests; }
            set { _requests = value; OnpropertyChanged(); }
        
        }

        Visibility _replyButtonVisibility;
        public Visibility ReplyButtonVisibility
        {
            get { return _replyButtonVisibility; }
            set { _replyButtonVisibility = value; OnpropertyChanged(); }
        }

        Visibility _sendButtonVisibility;
        public Visibility SendButtonVisibility
        {
            get { return _sendButtonVisibility; }
            set { _sendButtonVisibility = value; OnpropertyChanged(); }
        }

        Visibility _cancelButtonVisibility;
        public Visibility CancelButtonVisibility
        {
            get { return _cancelButtonVisibility; }
            set { _cancelButtonVisibility = value; OnpropertyChanged(); }
        }

        Visibility _replyTextBoxVisibility;
        public Visibility ReplyTextBoxVisibility
        {
            get { return _replyTextBoxVisibility; }
            set { _replyTextBoxVisibility = value; OnpropertyChanged(); }
        }

        #endregion


        #region commands

        public RelayCommand ReplyCommand { get; set; }
        public RelayCommand SendReplyCommand { get; set; }
        public RelayCommand CancelReplyCommand { get; set; }
        #endregion

        public AdminHomeVM()
        {

            SendButtonVisibility= Visibility.Collapsed;
            CancelButtonVisibility= Visibility.Collapsed;
            ReplyTextBoxVisibility= Visibility.Collapsed;


            ReplyCommand = new RelayCommand(MakeReply);
            SendReplyCommand = new RelayCommand(SendReply);
            CancelReplyCommand = new RelayCommand(CancelReply);

            _requests.Add(new Request("2023/10/11", "Problemas con mi Horario", "Kevin Rogers", "Pendiente"));
            _requests.Add(new Request("2023/09/23", "No veo mis clases", "Kevin Rogers", "Solucionada"));
            _requests.Add(new Request("2023/09/15", "Hay un error con la hora de una de mis asignaturas", "Kevin Rogers", "Pendiente"));
            _requests.Add(new Request("2023/08/10", "no me aparece la informacion de la clase", "Kevin Rogers", "Solucionada"));
        }

        #region execute Methods

        public void SendReply(object parameter)
        {
            ReplyButtonVisibility = Visibility.Visible;
            SendButtonVisibility = Visibility.Collapsed;
            CancelButtonVisibility = Visibility.Collapsed;
            ReplyTextBoxVisibility = Visibility.Collapsed;
        }

        public void MakeReply(object parameter) 
        {
            ReplyButtonVisibility = Visibility.Collapsed;
            SendButtonVisibility = Visibility.Visible;
            CancelButtonVisibility = Visibility.Visible;
            ReplyTextBoxVisibility = Visibility.Visible;
        }

        public void CancelReply(object parameter)
        {
            ReplyButtonVisibility = Visibility.Visible;
            SendButtonVisibility = Visibility.Collapsed;
            CancelButtonVisibility = Visibility.Collapsed;
            ReplyTextBoxVisibility = Visibility.Collapsed;
        }

        #endregion 


    }
}
