using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.Model;

namespace WebApplication1
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> person { get; set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }

        internal void Add(Person person)
        {
            throw new NotImplementedException();
        }
    }
}