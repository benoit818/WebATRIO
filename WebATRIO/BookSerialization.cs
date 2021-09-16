using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace WebATRIO
{
    public static class SerializerUtilities
    {
        public static Book Deserialize(string file)
        {
            Library[] libraries = null;
            string path = @"‪C:\Users\benoi\source\repos\WebATRIO\WebATRIO\library.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(Library[]));

            StreamReader reader = new StreamReader(path);
            reader.ReadToEnd();
            libraries = (Library[])serializer.Deserialize(reader);
            reader.Close();

            List<Book>books = libraries.SelectMany(x => x.Book).ToList();

            return books.First(x => x.Title.Contains ("roman"));
  
        }

        public static void XpathMethod(string file)
        {
            string fullName = "F:\\Programming\\XML\\Example XML.xml";
            XmlDocument xreader = new XmlDocument();

            xreader.Load(fullName);
            XmlNode root = xreader.DocumentElement;
            XmlNodeList xnList1 =
                   xreader.SelectNodes("library/Book/");

            XmlNodeList xnList2 =
                   xreader.SelectNodes(@"library/Book[@type='roman']/");

            XmlNodeList xnList3 =
                   xreader.SelectNodes(@"library/Book[@type='bd']/");

           int  nbelem = xnList3.Count;


        }
    }
}
