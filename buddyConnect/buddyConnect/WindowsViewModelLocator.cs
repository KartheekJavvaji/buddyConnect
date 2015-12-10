using buddyConnect.View_Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buddyConnect
{
    public class WindowsViewModelLocator : BaseViewModelLocator
    {
        public WindowsViewModelLocator() : base()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<INavigationService, NavigationService>();
            }
            else
            {
                var navigationService = InitNavigationService();
                SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            }
        }

        protected INavigationService InitNavigationService()
        {
            var service = new NavigationService();

            service.Configure(typeof(MainPageViewModel).FullName, typeof(MainPage));
            service.Configure(typeof(FindFriendsViewModel).FullName, typeof(findFriends));

            service.Configure(typeof(FriendLocationViewModel).FullName, typeof(friendLocation));
            service.Configure(typeof(HomeViewModel).FullName, typeof(home));

            service.Configure(typeof(NewUserViewModel).FullName, typeof(newuser));
            service.Configure(typeof(ProfileViewModel).FullName, typeof(profile));

            service.Configure(typeof(RequestsViewModel).FullName, typeof(requests));
            service.Configure(typeof(SettingsViewModel).FullName, typeof(settings));

            service.Configure(typeof(View_Models.homeviewmodels.BuddiesViewModel).FullName, typeof(homeviews.buddies));
            service.Configure(typeof(View_Models.homeviewmodels.ChatsViewModel).FullName, typeof(homeviews.chats));

            return service;
        }
    }
}
