using System;
using System.Collections.Generic;
using System.Text;

namespace DPoC
{
    [Serializable]
    [ProcAttribute("Memory", "Track")]
    public class MemoryProc : Proc, IProc
    {
        public int Memory { get; set; }

        public override void Hi()
        {
            Console.WriteLine("hi im memory proc");
        }
        public MemoryProc(string name)
        {
            Name = name;
        }

        public MemoryProc() { }
    }
}
