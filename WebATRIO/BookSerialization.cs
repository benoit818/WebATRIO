using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebATRIO
{
    public static class BookSerializer
    {
        public static Book Deserialize()
        {
            Library[] libraries = null;
            string path = @"‪C:\Users\benoi\source\repos\WebATRIO\WebATRIO\library.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(Library[]));

            StreamReader reader = new StreamReader(path);
            reader.ReadToEnd();
            libraries = (Library[])serializer.Deserialize(reader);
            reader.Close();

            List<Book>books =libraries.SelectMany(x => x.Book).ToList();

            return books.First(x => x.Title.Contains ("roman"));

  
        }
    }
}
