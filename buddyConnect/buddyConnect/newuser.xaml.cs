using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
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
using System.Net.Http;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace buddyConnect
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class newuser : Page
    {

        private HttpClient httpClient;
        private HttpResponseMessage responseMes;
        string gender;
        string statusString;
        bool emailInvalid;
        signup signupObj;
        public newuser()
        {
            this.InitializeComponent();
            httpClient = new HttpClient();
        }

        private async void signup_Click(object sender, RoutedEventArgs e)
        {
            string usernam = username.Text;
            string passwor = password.Password;
            string emai = email.Text;
            string responseBodyAsText = "";
            string getSign = "http://www.graylogictech.com/glt_cs/BuddyTrackerWebservice.asmx/RegisterUser?UserName=" + usernam + "&Password=" + passwor + "&Age=&Latitude=&Longitude=&Status=" + statusString + "&Email=" + emai + "&ProFile_ImgUrl=&condition=insert&gender=" + gender + "&phoneno=";

            //var mess = new MessageDialog(getSign);
            //await mess.ShowAsync();
            try
            {
                responseMes = await httpClient.GetAsync(getSign);

                responseMes.EnsureSuccessStatusCode();

                responseBodyAsText = await responseMes.Content.ReadAsStringAsync();

            }
            catch (Exception ex)
            {
                var mes = new MessageDialog(ex.ToString(), "error");
            }
            XmlSerializer x = new XmlSerializer(typeof(ResponseString));
            ResponseString myTest = (ResponseString)x.Deserialize(new StringReader(responseBodyAsText));
            string res = myTest.Text;
            signupObj = JsonConvert.DeserializeObject<signup>(res);
            if (signupObj.data[0].result == "true")
            {
                var mes2 = new MessageDialog("Hi " + usernam + ", you have successfully registered!");
                await mes2.ShowAsync();
                Frame.Navigate(typeof(login));
            }
            else
            if(signupObj.data[0].output=="email already exists")
            {
                var mes2 = new MessageDialog("The entered email is already associated with an other username");
                await mes2.ShowAsync();
                Frame.Navigate(typeof(newuser));
            }
            else
            if(signupObj.data[0].output=="userid exists")
            {
                var mes2 = new MessageDialog("username already exists");
                await mes2.ShowAsync();
                Frame.Navigate(typeof(newuser));
            }
            else
            {
                var mes5 = new MessageDialog("Please check the connection and try again in a few minutes");
                await mes5.ShowAsync();
                Frame.Navigate(typeof(newuser));
            }
        }

        private void username_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(username.Text))
            {
                password.IsEnabled = true;
            }
            else
            {
                password.IsEnabled = passwordR.IsEnabled = email.IsEnabled = maleRadio.IsEnabled = femaleRadio.IsEnabled = false;
            }

        }


        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(password.Password))
            {
                passwordR.IsEnabled = true;
            }
            else
            {
                email.IsEnabled = maleRadio.IsEnabled = femaleRadio.IsEnabled = false;
            }
        }
        private void passwordR_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passwordR.Password == password.Password)
            {
                email.IsEnabled = maleRadio.IsEnabled = femaleRadio.IsEnabled = true;
            }
            else
            {
                email.IsEnabled = maleRadio.IsEnabled = femaleRadio.IsEnabled = false;
            }

        }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {
            emailInvalid = false;
            if (!String.IsNullOrEmpty(email.Text))
            {

                // Use IdnMapping class to convert Unicode domain names.
                email.Text = Regex.Replace(email.Text, @"(@)(.+)$", this.DomainMapper);
                // Return true if strIn is in valid e-mail format.
                emailInvalid = !Regex.IsMatch(email.Text,
                       @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                       @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                       RegexOptions.IgnoreCase);
            }
            if (!emailInvalid)
                signup.IsEnabled = true;
            else
                signup.IsEnabled = false;
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                emailInvalid = true;
            }
            return match.Groups[1].Value + domainName;
        }

    
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (maleRadio.IsChecked == true)
                gender = "male";
            else
                gender = "female";
                
        }

        private void status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            statusString = combo.SelectedIndex.ToString();
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(login));
        }
    }
}
