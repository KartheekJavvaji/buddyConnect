using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using buddyConnect.Models.homemodels;
using buddyConnect.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace buddyConnect.View_Models.homeviewmodels
{
    public class BuddiesViewModel : BaseViewModel
    {
        private HttpClient httpClient;
        private HttpResponseMessage responseMes;
        List<loginCDatum> loginCObj;

        private ObservableCollection<loginCDatum> LoginCO = new ObservableCollection<loginCDatum>();
        private string responseBodyAsText;

        public ObservableCollection<loginCDatum> TestItems
        {
            get { return LoginCO; }
            set
            {
                LoginCO = value;
                RaisePropertyChanged();
            }
        }

        protected override void LoadDesignTimeData()
        {
            base.LoadDesignTimeData();          
        }

        public async override void LoadState(object navParameter, Dictionary<string, object> state)
        {
            base.LoadState(navParameter, state);
            httpClient = new HttpClient();
            if (!TestItems.Any())
            {
                string getLogin = "http://www.graylogictech.com/glt_cs/BuddyTrackerWebservice.asmx/authenticate?userid=sairam&pwd=1234&lat=&log=";
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
                loginCObj = JsonConvert.DeserializeObject<List<loginCDatum>>(res);
                LoginCO = new ObservableCollection<loginCDatum>(loginCObj);
                
            }
        }

    }
}
