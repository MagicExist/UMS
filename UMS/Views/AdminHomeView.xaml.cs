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

namespace UMS.Views
{
    /// <summary>
    /// Interaction logic for AdminHomeView.xaml
    /// </summary>
    public partial class AdminHomeView : UserControl
    {

        public Request item { get; set; }

        public AdminHomeView()
        {
            InitializeComponent();
        }

        private void RequestsList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //ListView listRequests = (ListView)sender;

            if (RequestsList.SelectedItem != null) 
            { 
                item= (Request)RequestsList.SelectedItem;
                DateSendRequests.Text = item.Date;
                subjectRequests.Text = item.Subject;
            }
        }
    }
}
