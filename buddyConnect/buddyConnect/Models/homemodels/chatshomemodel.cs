using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buddyConnect.Models.homemodels
{
    public class chatshomemodelDatum
    {
        public string result { get; set; }
        public string output { get; set; }
        public string sno { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string age { get; set; }
        public string createddate { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string status { get; set; }
        public string email { get; set; }
        public string profile_imgurl { get; set; }
        public string gender { get; set; }
        public string login_status { get; set; }
        public string intrests { get; set; }
        public string addictional_information { get; set; }
        public string looking_for { get; set; }
        public string body_type { get; set; }
        public string drinks { get; set; }
        public string height { get; set; }
        public string languages { get; set; }
        public string msgid { get; set; }
        public string user_from { get; set; }
        public string user_to { get; set; }
        public string conversation { get; set; }
        public string sentby { get; set; }
        public string datetime { get; set; }
        public object new_msg_status { get; set; }
    }

    public class chatshomemodel
    {
        public List<chatshomemodelDatum> data { get; set; }
    }
}
