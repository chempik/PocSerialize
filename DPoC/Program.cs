using System;

namespace DPoC
{
    class Program
    {
        private static Option option = new Option();

        static void Main(string[] args)
        {
          //  option.Create("for my");
           
             option.NewSirialize(@"XmlFiles\\ForNewTest.xml");
            option.Validate();
        }
    }
}
