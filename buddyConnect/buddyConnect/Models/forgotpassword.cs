using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buddyConnect.Models
{
    public class forgotpasswordDatum
    {
        public string result { get; set; }
        public string output { get; set; }
    }

    public class forgotpasswordClass
    {
        public List<forgotpasswordDatum> data { get; set; }
    }
}
