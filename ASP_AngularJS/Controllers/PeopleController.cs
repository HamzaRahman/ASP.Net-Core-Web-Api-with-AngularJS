using ASP_AngularJS.Models;
using ASP_AngularJS.Repo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_AngularJS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : Controller
    {
        PeopleRepo _peopleRepo;
        public PeopleController(PeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }
        public void Index()
        {
        }
        [HttpGet]
        public List<Person> GetPeople()
        {
            return _peopleRepo.Read();
        }
        [HttpPost]
        public void AddPerson([FromBody]Person person)
        {
            _peopleRepo.Create(person);
        }
        [HttpPut]
        public void UpdatePerson([FromBody] Person person)
        {
            _peopleRepo.Update(person);
        }
        [HttpDelete("{id:int}")]
        public void DeletePerson(int id)
        {
            Debug.WriteLine(id);
            var person = _peopleRepo.Read(id);
            _peopleRepo.Delete(person);
        }
    }
}
