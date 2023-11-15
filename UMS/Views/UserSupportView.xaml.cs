using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using UMS.Models.UsersModels;

namespace UMS.Views
{
    /// <summary>
    /// Interaction logic for UserSupportView.xaml
    /// </summary>
    public partial class UserSupportView : UserControl
    {
        private ObservableCollection<Request> Requests;
        private User currentUser;

        public UserSupportView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new User, inserts a new Request into the database, loads requests, and updates the UserRequestsList.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">containing event data.</param>
        private void BtnEnviar_Click(object sender, RoutedEventArgs e)
        {
            currentUser = new User() { Document = CurrentDocument.Text };
            RequestInsertDB requestInsertDB = new RequestInsertDB();
            OpenDbConnection openDbConnection = new OpenDbConnection();
            SqlConnection currentConnection = openDbConnection.openConnection();
            Request currentRequest = new Request() { Subject = Subject.Text, Details = Details.Text };

            requestInsertDB.InsertRequest(currentConnection, currentRequest, currentUser);



            #region LoadScheduler
            
            RequestDB requestDB = new RequestDB();
            Requests = requestDB.loadRequest(currentConnection, currentUser, 2);
            currentConnection.Close();
            #endregion


            UserRequestsList.ItemsSource = Requests;
        }
    }
}
