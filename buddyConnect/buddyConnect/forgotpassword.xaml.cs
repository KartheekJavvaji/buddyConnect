using buddyConnect.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class forgotpassword : Page
    {
        private HttpClient httpClient;
        private HttpResponseMessage responseMes;
        forgotpassword forgotpasswordObj;
        public forgotpassword()
        {
            this.InitializeComponent();
            httpClient = new HttpClient();
        }

        private async void forgotPassword_Click(object sender, RoutedEventArgs e)
        {
            string forgotpasswordSt = "http://www.graylogictech.com/glt_cs/BuddyTrackerWebservice.asmx/RegisterUser?UserName=" + usernam + "&Password=" + passwor + "&Age=&Latitude=&Longitude=&Status=" + statusString + "&Email=" + emai + "&ProFile_ImgUrl=&condition=insert&gender=" + gender + "&phoneno=";

            string responseBodyAsText = "";
            //var mess = new MessageDialog(getSign);
            //await mess.ShowAsync();
            try
            {
                responseMes = await httpClient.GetAsync(forgotpasswordSt);

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
            forgotpasswordObj = JsonConvert.DeserializeObject<forgotpassword>(res);
            var mes2 = new MessageDialog(username.Text + ", follow the intructions sent to your mail.");
            await mes2.ShowAsync();
            if()
        }
    }
}
