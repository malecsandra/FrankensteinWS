using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrankensteinWS.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string FullName { get; set; }
        public Nullable<int> PersonId { get; set; }
        public bool StatusId { get; set; }

        public PersonModel PersonModel { get; set; }

    }
}