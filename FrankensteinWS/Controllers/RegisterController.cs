using AutoMapper;
using FrankensteinWS.Models;
using FrankensteinWS.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FrankensteinWS.Controllers
{
    public class RegisterController : BaseController
    {
        // GET api/register
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/register/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/register
        public void Post(UserModel usermodel)
        {
      
            User user = db.Users.FirstOrDefault(u => u.UserName == usermodel.UserName);

            if(user == null)
            {

                var configP = new MapperConfiguration(cfg => cfg.CreateMap<PersonModel, Person>());
                var mapperP = configP.CreateMapper();

                Person NewPerson = new Person();
                NewPerson = mapperP.Map<Person>(usermodel.PersonModel);

                var config = new MapperConfiguration(cfg => cfg.CreateMap<UserModel, User>());
                var mapper = config.CreateMapper();

                User NewUser = new User();
                NewUser = mapper.Map<User>(usermodel);

                NewPerson.Users.Add(NewUser);

                db.People.Add(NewPerson);
                db.SaveChanges();
            }
            else
            {
                throw UsernameTaken(Warnings.usernameExists);
            }
           
        }

        // PUT api/register/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/register/5
        public void Delete(int id)
        {
        }
    }
}
