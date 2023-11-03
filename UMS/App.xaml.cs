using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UMS.Stores;
using UMS.ViewModels;
using UMS.Views;

namespace UMS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            LoginStore loginStore = new LoginStore();
            
            DashBoardStudentVM dashBoardStudentVM = new DashBoardStudentVM();

            LoginVM loginVM = new LoginVM();
            
            loginVM.LoginStore = loginStore;
            loginVM.DashBoardStudentVM = dashBoardStudentVM;

            MainVM mainVM = new MainVM();

            mainVM.LoginStore = loginStore;
            mainVM.currentView = loginVM;
            mainVM.LoginStore.OnLoginAllow += mainVM.OnLoginAllowSub;

            MainWindow MainWindow = new MainWindow()
            {
                DataContext = mainVM
            };


            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
