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
    /// Interaction logic for SearchClassRoomView.xaml
    /// </summary>
    public partial class SearchClassRoomView : UserControl
    {
        public ClassRoom SelectedClassRoom { get; set; }

        public SearchClassRoomView()
        {
            InitializeComponent();
        }

        private void cancelAssign_Click(object sender, RoutedEventArgs e)
        {
            AssignGroup.Visibility = Visibility.Collapsed;
        }

        private void Classrooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (Classrooms.SelectedItem != null)
            {
                SelectedClassRoom = (ClassRoom)Classrooms.SelectedItem;
                ClassRoomCode.Text = SelectedClassRoom.Code;

                if (SelectedClassRoom.Status == "Libre")
                {
                    AssignGroup.Visibility = Visibility.Visible;
                }
                else 
                {
                    AssignGroup.Visibility = Visibility.Collapsed;
                }

            }
        }
    }
}
