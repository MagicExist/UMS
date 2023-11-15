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
    /// Interaction logic for UserHomeView.xaml
    /// </summary>
    public partial class UserHomeView : UserControl
    {
        public Class SelectedClass { get; set; } 

        public UserHomeView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Updates the displayed information when a class is selected.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Contains event data</param>
        private void ClassList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (ClassList.SelectedItem != null)
            {
                SelectedClass = (Class)ClassList.SelectedItem;
                course.Text = SelectedClass.Course;
                group.Text = SelectedClass.IdGroup;
                classroom.Text = SelectedClass.IdClassRoom;
                detailClass.Text = SelectedClass.Details;
            }
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            DetailsUpdateDB detailsUpdateDB = new DetailsUpdateDB();
            OpenDbConnection openDbConnection = new OpenDbConnection();
            SelectedClass.Details = detailClass.Text;
            SqlConnection currentConnection = openDbConnection.openConnection();

            detailsUpdateDB.InsertDetail(currentConnection, SelectedClass);
        }
    }
}
