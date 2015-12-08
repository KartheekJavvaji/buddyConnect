using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using buddyConnect.Models;
using Newtonsoft.Json;
using System.Xml;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace buddyConnect
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class login : Page
    {
        private HttpClient httpClient;
        private HttpResponseMessage responseMes;
        loginC loginCObj;
        
        public login()
        {
            this.InitializeComponent();
            httpClient = new HttpClient();
            var headers = httpClient.DefaultRequestHeaders;
            headers.UserAgent.ParseAdd("ie");
            headers.UserAgent.ParseAdd("Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");

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

        private void newUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            responseMes = new HttpResponseMessage();

            // The value of 'InputAddress' is set by the user and is therefore untrusted input. 
            // If we can't create a valid URI, 
            // We notify the user about the incorrect input.

            string responseBodyAsText;


            try
            {
                responseMes = await httpClient.GetAsync("http://www.graylogictech.com/glt_cs/BuddyTrackerWebservice.asmx/authenticate?userid=sairam&pwd=1234&lat=&log=");

                responseMes.EnsureSuccessStatusCode();

                responseBodyAsText = await responseMes.Content.ReadAsStringAsync();

            }
            catch (Exception ex)
            {
                // Need to convert int HResult to hex string
                usernameTb.Text = "Error = " + ex.HResult.ToString("X") +
                    "  Message: " + ex.Message;
                responseBodyAsText = "";
            }
            usernameTb.Text = responseBodyAsText;
            DataContext = loginCObj;

        }
    }
}
