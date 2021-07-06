using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
namespace DPoC
{
    //[XmlRoot(Namespace = DPoC,)]
    [Serializable]
    [ProcAttribute("Memory", "Track")]
    [XmlInclude(typeof(MemoryProc))]
    public class MemoryProc : Proc, IProc
    {
        public int Memory { get; set; }

        public override void Hi()
        {
            Console.WriteLine($"hi im memory proc {Name}");
        }

        public MemoryProc(string name)
        {
            Name = name;
        }

        public MemoryProc() { }
    }
}
