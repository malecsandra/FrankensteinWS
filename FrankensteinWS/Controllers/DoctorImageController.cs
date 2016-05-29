using FrankensteinWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FrankensteinWS.Controllers
{
    public class DoctorImageController : BaseController
    {
        // GET api/doctorimage
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/doctorimage/1
        public DoctorImageModel Get(int id)
        {
            byte[] photo;
            photo = db.DoctorImages.Where(p => p.DoctorId == id).FirstOrDefault().Photo;

            DoctorImageModel d = new DoctorImageModel();
            d.Photo = photo;
            d.DoctorId = id;

            return d;
        }

        // POST api/doctorimage
        public void Post([FromBody]string value)
        {
        }

        // PUT api/doctorimage/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/doctorimage/5
        public void Delete(int id)
        {
        }
    }
}
