using ASP_AngularJS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_AngularJS.Repo
{
    public class PeopleRepo
    {
        PeopleContext _DB;
        public PeopleRepo(PeopleContext _DB)
        {
            this._DB = _DB;
        }
        public Person Create(Person p)
        {
            _DB.People.Add(p);
            _DB.SaveChanges();
            return p;
        }
        
        public bool Delete(Person person)
        {
            if (_DB.People.Contains(person))
            {
                _DB.People.Remove(person);
                _DB.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Person> Read()
        {
            return _DB.People.AsParallel().ToList();
        }

        public Person Read(int ID)
        {
            return _DB.People.FirstOrDefault(person => person.ID == ID);
        }

        public Person Update(Person person)
        {
            var ToBeUpdate = _DB.People.FirstOrDefault(p => p.ID == person.ID);
            if (ToBeUpdate != null)
            {
                _DB.Entry(ToBeUpdate).CurrentValues.SetValues(person);
            }
            return person;
        }
    }
}
