using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DPoC
{
    [Serializable]
    [XmlRootAttribute]
    [ProcAttribute("Proc", "Track")]
    [XmlInclude(typeof(Proc))]
    public class Proc : IProc
    {
        public string Name { get; set; }
        public Proc(string name)
        {
            Name = name;
        }
        public Proc() { }

        public virtual void Hi()
        {
            Console.WriteLine($"Hi, im Proc {Name}");
        }
    }
}
