using System;
using System.Collections.Generic;
using System.Text;

namespace DPoC
{
    [Serializable]
    [ProcAttribute("Autorun", "Track")]
    public class AutorunProc : Proc, IProc
    {
        public bool Autorun { get; set; }
        public override void Hi()
        {
            Console.WriteLine("Hi, am AutorunProc");
        }

        public AutorunProc(string name)
        {
            Name = name;
        }

        public AutorunProc() { }
    }
}
