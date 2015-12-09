using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buddyConnect.Models
{
    public class signupDatum
    {
        public string result { get; set; }
        public string output { get; set; }
    }

    public class signup
    {
        public List<signupDatum> data { get; set; }
    }
}
