using AutoMapper;
using FrankensteinWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FrankensteinWS.Controllers
{
    public class UsersController : BaseController
    {

        // GET api/Users/5
        public UserModel Get(int id)
        {

            User userTest = db.Users.Where(u => u.UserId == id).FirstOrDefault();


            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());
            var mapper = config.CreateMapper();
            UserModel toReturn = mapper.Map<UserModel>(userTest);
            

            //List<Visit> visits = userTest.Visits.ToList();

            //List<User> users = db.Users.ToList();

            //string name = db.Users.Where(u => u.UserId == 1).Select(u => u.UserName).FirstOrDefault();

            /*List<Visit> visits2 = db.Visits.Where(v => v.ID_USER == userTest.ID).ToList();

            List<GetUsersTest_Result> result = db.GetUsersTest(null).ToList();
            */
            return toReturn;
        }

        public void Post(int id, [FromBody]User PostUser)
        {
            User user = db.Users.Where(u => u.UserId == id).FirstOrDefault();
            if (user == null)
            {
                //user nu exista in bd
            }
            else
            {
                user.UserName = PostUser.UserName;
                user.UserPassword = PostUser.UserPassword;
                db.SaveChanges();
            }
        }

        public void Put([FromBody]User PostUser)
        {
            User NewUser = new User();
            NewUser.UserName = PostUser.UserName;
            NewUser.UserPassword = PostUser.UserPassword;

            db.Users.Add(NewUser);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = new User { UserId = 1 };
            db.Users.Attach(user);
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}
