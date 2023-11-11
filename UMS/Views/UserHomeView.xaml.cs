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
    /// Interaction logic for UserHomeView.xaml
    /// </summary>
    public partial class UserHomeView : UserControl
    {
        public Class Item { get; set; } 

        public UserHomeView()
        {
            InitializeComponent();
        }

        private void ClassList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            ListView listClass = (ListView)sender; 

            if (ClassList.SelectedItem != null)
            {
                Item = (Class)listClass.SelectedItem;
                course.Text = Item.Course;
                group.Text = Item.IdGroup;
                classroom.Text = Item.IdClassRoom;
                detailClass.Text = Item.Details;
            }
        }
    }
}
