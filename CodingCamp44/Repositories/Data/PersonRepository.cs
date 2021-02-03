using CodingCamp44.Context;
using CodingCamp44.Models;
using Microsoft.EntityFrameworkCore;
using CodingCamp44.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCamp44.Repositories.Data
{
    public class PersonRepository : GeneralRepository<Person, MyContext, string>
    {
        private readonly MyContext myContext;
        private DbSet<Person> persons;

        public PersonRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
            myContext.Set<Person>();
            persons = myContext.Set<Person>();
        }

        public Person GetDataByEmail(string email)
        {
            var data = myContext.Persons.Where(e => e.Email == email).FirstOrDefault();
            return data;
        }
    }
}
