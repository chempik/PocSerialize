using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DPoC
{
    [Serializable]
    [ProcAttribute("Autorun", "Track")]
    [XmlInclude(typeof(AutorunProc))]
    public class AutorunProc : Proc, IProc
    {
        public bool Autorun { get; set; }
        public override void Hi()
        {
            Console.WriteLine($"Hi, am AutorunProc {Name}") ;
        }

        public AutorunProc(string name)
        {
            Name = name;
        }

        public AutorunProc() { }
    }
}
