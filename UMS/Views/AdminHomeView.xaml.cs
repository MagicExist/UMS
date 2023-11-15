using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UMS.Models;
using UMS.Models.ModelsDB;

namespace UMS.Views
{
    /// <summary>
    /// Interaction logic for AdminHomeView.xaml
    /// </summary>
    public partial class AdminHomeView : UserControl
    {
        enum userType
        {
            Admin = 1,
            Professor = 2,
            Student = 3
        }
        public Request SelectedRequest { get; set; }

        public AdminHomeView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the MouseLeftButtonUp event for the RequestsList.
        /// Updates the displayed information when a request is selected.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Contains event data</param>
        private void RequestsList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (RequestsList.SelectedItem != null) 
            { 
                SelectedRequest= (Request)RequestsList.SelectedItem;
                DateSendRequests.Text = SelectedRequest.Date;
                subjectRequests.Text = SelectedRequest.Subject;
                DetailsRequests.Text = SelectedRequest.Details;
                CodeNameRequests.Text = SelectedRequest.UserDocument;
                UserTypeRequests.Text = SelectedRequest.UserType;
                ReplyRequestsView.Text = SelectedRequest.Reply;


                if (SelectedRequest.Status == "Respondida")
                {
                    ReplyView.Visibility = Visibility.Visible;
                    SendButton.Visibility = Visibility.Collapsed;
                }
                else 
                {
                    ReplyView.Visibility = Visibility.Collapsed;
                    SendButton.Visibility = Visibility.Visible;
                }


            }
        }
        /// <summary>
        /// sends a response to the database 
        /// </summary>
        /// <param name="parameter">Optional parameter that can be used to pass additional information from the view.</param>
        private void SendRequestButton_Click(object sender, RoutedEventArgs e)
        {
            RequestUpdateDB requestUpdateDB = new RequestUpdateDB();
            OpenDbConnection openDbConnection = new OpenDbConnection();
            SelectedRequest.Reply = ReplyRequests.Text;
            ReplyRequestsView.Text = SelectedRequest.Reply;
            SelectedRequest.Status = "Respondida";
            SqlConnection currentConnection = openDbConnection.openConnection();

            requestUpdateDB.InsertRequest(currentConnection,SelectedRequest);

            ReplyView.Visibility = Visibility.Visible;
            SendButton.Visibility = Visibility.Collapsed;
            CancelButton.Visibility = Visibility.Collapsed;
            SendRequestButton.Visibility = Visibility.Collapsed;
            ReplyRequests.Visibility = Visibility.Collapsed;

        }
    }
}