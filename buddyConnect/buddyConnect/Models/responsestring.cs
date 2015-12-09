using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace buddyConnect.Models
{
    [XmlRoot(ElementName = "string", Namespace = "http://tempuri.org/")]
    public class ResponseString
    {
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
}
