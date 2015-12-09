using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buddyConnect.Models.homemodels
{
    public class buddieshomeDatum
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
    }

    public class buddieshome
    {
        public List<buddieshomeDatum> data { get; set; }
    }

    //public class Buddies
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public string Subtitle { get; set; }
    //    public string HexColor { get; set; }
    //}
}
