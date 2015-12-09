using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using buddyConnect.View_Models.homeviewmodels;

namespace buddyConnect.View_Models
{
      public class BaseViewModelLocator
    {
        public BaseViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<FindFriendsViewModel>();
            SimpleIoc.Default.Register<FriendLocationViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<NewUserViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.Register<RequestsViewModel>();
            SimpleIoc.Default.Register<ProfileViewModel>();
            SimpleIoc.Default.Register<BuddiesViewModel>();
            SimpleIoc.Default.Register<ChatsViewModel>();
        }

        public MainPageViewModel MainPage
        {
            get { return ServiceLocator.Current.GetInstance<MainPageViewModel>(); }
        }

        public FindFriendsViewModel findfriends
        {
            get { return ServiceLocator.Current.GetInstance<FindFriendsViewModel>(); }
        }
        public FriendLocationViewModel friendlocation
        {
            get { return ServiceLocator.Current.GetInstance<FriendLocationViewModel>(); }
        }
        public HomeViewModel home
        {
            get { return ServiceLocator.Current.GetInstance<HomeViewModel>(); }
        }
        public NewUserViewModel newuser
        {
            get { return ServiceLocator.Current.GetInstance<NewUserViewModel>(); }
        }
        public SettingsViewModel settings
        {
            get { return ServiceLocator.Current.GetInstance<SettingsViewModel>(); }
        }
        public RequestsViewModel requests
        {
            get { return ServiceLocator.Current.GetInstance<RequestsViewModel>(); }
        }
        public ProfileViewModel profile
        {
            get { return ServiceLocator.Current.GetInstance<ProfileViewModel>(); }
        }
        public BuddiesViewModel buddies
        {
            get { return ServiceLocator.Current.GetInstance<BuddiesViewModel>(); }
        }
        public ChatsViewModel chats
        {
            get { return ServiceLocator.Current.GetInstance<ChatsViewModel>(); }
        }


    }
}
