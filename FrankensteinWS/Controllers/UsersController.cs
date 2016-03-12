using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FrankensteinWS.Controllers
{
    public class UsersController : ApiController
    {
        FrankensteinEntities db = new FrankensteinEntities();
        // GET api/Users/5
        public User Get(int id)
        {
            User userTest = db.Users.Include("Visits").Where(u => u.ID == id).FirstOrDefault();
            /*List<Visit> visits = userTest.Visits.ToList();

            List<User> users = db.Users.ToList();

            string name = db.Users.Where(u => u.ID == 1).Select(u => u.NAME).FirstOrDefault();

            List<Visit> visits2 = db.Visits.Where(v => v.ID_USER == userTest.ID).ToList();

            List<GetUsersTest_Result> result = db.GetUsersTest(null).ToList();
            */
            return userTest;
        }

        public void Post(int id, [FromBody]User PostUser)
        {
            User user = db.Users.Where(u => u.ID == id).FirstOrDefault();
            if (user == null)
            {
                //user nu exista in bd
            }
            else
            {
                user.NAME = PostUser.NAME;
                user.PASSWORD = PostUser.PASSWORD;
                db.SaveChanges();
            }
        }

        public void Put([FromBody]User PostUser)
        {
            User NewUser = new User();
            NewUser.NAME = PostUser.NAME;
            NewUser.PASSWORD = PostUser.PASSWORD;

            db.Users.Add(NewUser);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = new User { ID = 1 };
            db.Users.Attach(user);
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}
