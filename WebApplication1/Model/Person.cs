using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class Person
    {
        public Guid id { get; set; }
        public string Nom { get; set; }
        public string Prenom{get; set;}
        public DateTime Naissance { get; set; }

    }
}
