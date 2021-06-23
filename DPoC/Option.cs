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

        public List<IProc> clases = new List<IProc>();
        public void Create(string name)
        {
            Proc[] array = new Proc[] { new AutorunProc("Kek") };

            string fileName = $@"XmlFiles\{name}.xml";
            SerializeXml(fileName,array,fileName);
        }

        private void SerializeXml(string name, Proc[] seting, string file)
        {
            var proces = new Proc(name,seting);
            XmlSerializer formatter = new XmlSerializer(typeof(Proc), _list);

            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, proces);
            }
        }

        private Proc Deserialize(string file)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Proc), _list);
            XDocument xdoc = XDocument.Load(file);
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                Proc newProces = (Proc)formatter.Deserialize(fs);
                return newProces;
            }
        }

        private List<Proc> DeserializeContinue()
        {
            string files = @"XmlFiles";
            string[] FileArray = Directory.GetFiles(files);
            List<Proc> list = new List<Proc>();

            foreach (string i in FileArray)
            {
                list.Add(Deserialize(i));
            }

            return list;
        }

        public void Validate()
        {
            var XmlList = DeserializeContinue();
            foreach (var i in XmlList)
            {
                //var exemp = Activator.CreateInstance(i) as IProc;
                //clases.Add(exemp);
                if (i.Setting.Length > 0)
                {
                    foreach (var j in i.Setting)
                    {
                        j.Hi();
                    }
                }
                Console.WriteLine(i.Setting);
            }
        }
    }
}
