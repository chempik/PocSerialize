using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DPoC
{
    class Option
    {
        private Type[] _list = Assembly.GetExecutingAssembly()
                          .GetTypes()
                          .Where(x => x.GetCustomAttribute<ProcAttribute>(true) != null)
                          .ToArray();

        public Rule NewDesirialize(string file)
        {
            var atters = new XmlAttributes();
            var over = new XmlAttributeOverrides();

            foreach (var i in _list)
            {
                var attr = new XmlElementAttribute();
                attr.ElementName = i.Name;
                attr.Type = i;
                atters.XmlElements.Add(attr);
            }

            over.Add(typeof(Rule), nameof(Rule.Proceses), atters);

            var s = new XmlSerializer(typeof(Rule),over);

            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                return (Rule)s.Deserialize(fs);
            }
        }

        public void NewSirialize (string file)
        {
            var attrs = new XmlAttributes();

           foreach ( var i in _list)
            {
                var attr = new XmlElementAttribute();
                attr.ElementName = i.Name;
                attr.Type = i;
                attrs.XmlElements.Add(attr);
            }

            var attrOver = new XmlAttributeOverrides();
            attrOver.Add(typeof(Rule), nameof(Rule.Proceses), attrs);
            var s = new XmlSerializer(typeof(Rule), attrOver);
            // TextWriter writer = new StreamWriter(file);
            //@"XmlFiles\\ForTest.xml"
            var rule = new Rule();

            List<Proc> list = new List<Proc>();
            list.Add(new AutorunProc("kek"));
            list.Add(new Proc("kek"));
           // list.Add(new MemoryProc("kek"));
            rule.Proceses = list.ToArray();

           // s.Serialize(writer, rule);
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                s.Serialize(fs, rule);
            }

            //writer.Close();
        }

        private List<Rule> DeserializeContinue()
        {
            string files = @"XmlFiles";
            string[] FileArray = Directory.GetFiles(files);
            List<Rule> list = new List<Rule>();

            foreach (string i in FileArray)
            {
                list.Add(NewDesirialize(i));
            }

            return list;
        }

        public void Validate()
        {
            var XmlList = DeserializeContinue();
            foreach (var i in XmlList)
            {
                if (i.Proceses.Length > 0)
                {
                    foreach (var j in i.Proceses)
                    {
                        j.Hi();
                    }
                }
            }
        }
    }
}