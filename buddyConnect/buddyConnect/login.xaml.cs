using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Xml.Serialization;
using System.Net.Http;
using System.Collections.ObjectModel;

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
            Frame.Navigate(typeof(newuser));
        }

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            // The value of 'InputAddress' is set by the user and is therefore untrusted input. 
            // If we can't create a valid URI, 
            // We notify the user about the incorrect input.
             
            string responseBodyAsText="";

            string getLogin= "http://www.graylogictech.com/glt_cs/BuddyTrackerWebservice.asmx/authenticate?userid="+username.Text+"&pwd="+password.Password+"&lat=&log=";
            try
            {
                responseMes = await httpClient.GetAsync(getLogin);

                responseMes.EnsureSuccessStatusCode();

                responseBodyAsText = await responseMes.Content.ReadAsStringAsync();

            }
            catch (Exception ex)
            {
                // Need to convert int HResult to hex string
                var mes = new Windows.UI.Popups.MessageDialog(ex.ToString());
            }

            XmlSerializer x = new XmlSerializer(typeof(ResponseString));
            ResponseString myTest = (ResponseString)x.Deserialize(new StringReader(responseBodyAsText));
            string res = myTest.Text;
            loginCObj = JsonConvert.DeserializeObject<loginC>(res);
            if (loginCObj.data[0].result == "true")
            {
                Frame.Navigate(typeof(MainPage),loginCObj);

            }
            else
            {
                password.Password = string.Empty;
                error.Visibility = Visibility.Visible;
            }

        }

        private void forgotPassword_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(forgotpassword));
        }
    }
    
}
