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
            #region DeclareObjects
            //ViewModels
            UserSupportVM userSupportVM = new UserSupportVM();
            userHomeVM userHomeVM = new userHomeVM();
            AdminHomeVM adminHomeVM = new AdminHomeVM();
            LoginVM loginVM = new LoginVM();
            UserVM userVM = new UserVM();
            MainVM mainVM = new MainVM();
            //Stores
            LoginStore loginStore = new LoginStore();
            #endregion
            loginVM.LoginStore = loginStore;
            loginVM.UserVM = userVM;
            loginVM.UserSupportVM = userSupportVM;
            loginVM.UserHomeVM= userHomeVM;
            loginVM.AdminHomeVM= adminHomeVM;




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
