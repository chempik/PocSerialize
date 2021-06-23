using System;
using System.Collections.Generic;
using System.Text;

namespace DPoC
{
    public class ProcAttribute : Attribute
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ProcAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
