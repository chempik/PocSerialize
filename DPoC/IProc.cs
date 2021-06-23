using System;
using System.Collections.Generic;
using System.Text;

namespace DPoC
{
    public interface IProc
    {
        public string Name { get; set; }

        public void Hi();
    }
}
