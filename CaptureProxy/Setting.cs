using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CaptureProxy
{
    public class Setting
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Title")]
        public string Title { get; set; }

        [XmlAttribute("OffsetX")]
        public int OffsetX { get; set; }

        [XmlAttribute("OffsetY")]
        public int OffsetY { get; set; }

        [XmlAttribute("Width")]
        public int Width { get; set; }

        [XmlAttribute("Height")]
        public int Height { get; set; }

        [XmlAttribute("DrawCursor")]
        public bool DrawCursor { get; set; }

        [XmlAttribute("Interval")]
        public int Interval { get; set; } = 33;

        [XmlAttribute("ShowFPS")]
        public bool ShowFPS { get; set; }
    }
}
