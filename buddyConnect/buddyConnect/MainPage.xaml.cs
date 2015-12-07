using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace buddyConnect
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //backButton.Visibility = Visibility.Collapsed;
            contentFrame.Navigate(typeof(home));
        }

        private void hamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }

        private void menuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = menuItems.Items.Cast<ListBoxItem>()
                .Where(p => p.IsSelected)
                .Select(t => t.Name)
                .ToArray();

            titleText.Text = selected[0];
            switch (selected[0])
            {
                case "home":
                    contentFrame.Navigate(typeof(home));
                    break;

                case "profile":
                    contentFrame.Navigate(typeof(profile));                   
                    break;
                case "findFriends":
                    contentFrame.Navigate(typeof(findFriends));
                    break;

                case "requests":
                    contentFrame.Navigate(typeof(requests));
                    break;
                case "friendLocation":
                    contentFrame.Navigate(typeof(friendLocation));
                    break;

                case "settings":
                    contentFrame.Navigate(typeof(settings));
                    break;
                
                default:
                    break;
            }

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {


            if (contentFrame.CanGoBack)
            {
                contentFrame.GoBack();
            }
        }
    }
}
