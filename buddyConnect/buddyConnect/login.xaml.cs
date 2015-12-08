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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace buddyConnect
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class login : Page
    {
        public login()
        {
            this.InitializeComponent();
        }

        private void username_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(username.Text))
                password.IsEnabled = true;
            else
                loginButton.IsEnabled = false;
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if ((!string.IsNullOrEmpty(password.Password)) && (!string.IsNullOrEmpty(username.Text)))
                loginButton.IsEnabled = true;
            else
                loginButton.IsEnabled = false;
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void newUser_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
