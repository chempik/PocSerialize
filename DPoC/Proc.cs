using System;
using System.Collections.Generic;
using System.Text;

namespace DPoC
{
    [Serializable]
    [ProcAttribute("Proc", "Track")]
    public class Proc : IProc
    {
        public string Name { get; set; }
        public Proc[] Setting { get; set; }
        public Proc(string name, Proc[] setting)
        {
            Setting = setting;
        }
        public Proc() { }

        public virtual void Hi()
        {
            Console.WriteLine("Hi, im Proc");
        }
    }
}
