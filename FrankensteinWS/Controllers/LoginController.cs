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
    public class LoginController : BaseController
    {
        // GET api/login
        public LoginModel Get(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }

        // GET api/login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/login
        public UserModel Post(LoginModel loginModel)
        {
            UserModel toReturn = new UserModel();
            User user = db.Users.FirstOrDefault(u => u.UserName == loginModel.username);

            if (user == null)
            {
                throw BadCredential(Warnings.badCredential);
            }
            else if (user.UserPassword != loginModel.password)
            {
                throw BadCredential(Warnings.badCredential);
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());
            var mapper = config.CreateMapper();

            toReturn = mapper.Map<UserModel>(user);
            toReturn.PersonModel = new PersonModel();
            

            var configP = new MapperConfiguration(cfg => cfg.CreateMap<Person, PersonModel>());
            var mapperP = configP.CreateMapper();
            toReturn.PersonModel = mapperP.Map<PersonModel>(user.Person);

            return toReturn;
        }

        // PUT api/login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/login/5
        public void Delete(int id)
        {
        }
    }
}
