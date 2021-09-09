using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebATRIO
{
    [Serializable()]
    public class Book
    {
        [System.Xml.Serialization.XmlAttribute("type")]
        public string Type { get; set; }

        [System.Xml.Serialization.XmlElement("title")]
        public string Title { get; set; }

        [System.Xml.Serialization.XmlElement("author")]
        public string Author { get; set; }

  
    }

    [Serializable()]
    [System.Xml.Serialization.XmlRoot("library")]
    public class Library
    {
        [XmlArray("library")]
        [XmlArrayItem("book", typeof(Book))]
        public Book[] Book { get; set; }
    }

    //nexiste pas mais on peut le rajouter dans le fichier pr plus de coherence.
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("libraries")]
    public class Libraries
    {
        [XmlArray("libraries")]
        [XmlArrayItem("library", typeof(Library))]
        public Library[] Book { get; set; }
    }
}
