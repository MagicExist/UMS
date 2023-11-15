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
            SearchClassRoomVM searchClassRoomVM = new SearchClassRoomVM();   
            LoginVM loginVM = new LoginVM();
            UserVM userVM = new UserVM();
            MainVM mainVM = new MainVM();
            //Stores
            LoginStore loginStore = new LoginStore();
            LoadRequestStore loadRequestStore = new LoadRequestStore();
            #endregion

            #region EventsSubscribers
            loginStore.OnLoginAllow += mainVM.OnLoginAllowSub;
            loadRequestStore.OnLoadRequest += userSupportVM.OnLoadRequestSub;
            loadRequestStore.OnLoadRequest += adminHomeVM.OnLoadRequestSub;
            #endregion


            loginVM.LoginStore = loginStore;
            loginVM.UserVM = userVM;
            loginVM.UserSupportVM = userSupportVM;
            loginVM.UserHomeVM= userHomeVM;
            loginVM.AdminHomeVM= adminHomeVM;
            loginVM.SearchClassRoomVM = searchClassRoomVM;
            loginVM.LoadRequestStore = loadRequestStore;

            userVM.AdminHomeVM= adminHomeVM;
            userVM.UserSupportVM= userSupportVM;
            userVM.UserHomeVM = userHomeVM;
            userVM.SearchClassRoomVM = searchClassRoomVM;
            userVM.LoadRequestStore = loadRequestStore;

            mainVM.LoginStore = loginStore;
            mainVM.currentView = loginVM;
            mainVM.UserVM = userVM;
            mainVM.LoginVM = loginVM;
            

            MainWindow MainWindow = new MainWindow()
            {
                DataContext = mainVM
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
