using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CaptureProxy
{
    public class Settings
    {
        [XmlArray("Datas")]
        [XmlArrayItem("Data")]
        public List<Setting> Datas { get; set; }
    }
}
