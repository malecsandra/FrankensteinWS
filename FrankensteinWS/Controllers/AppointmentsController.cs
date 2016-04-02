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
    public class AppointmentsController : BaseController
    {
        // GET api/appoiments
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/appoiments/5
        public List<AppointmentModel> Get(int id)
        {
            List<AppointmentModel> toReturn = new List<AppointmentModel>();
            
            List<Appointment> dbApps = new List<Appointment>();
            dbApps = db.Appointments.Where(a => a.PersonId == id).ToList();
            
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Appointment, AppointmentModel>());
            var mapper = config.CreateMapper();

            foreach (var dbApp in dbApps)
            {
                AppointmentModel appModel = mapper.Map<AppointmentModel>(dbApp);
                appModel.Doctor = dbApp.Doctor.Name;
                appModel.Specialitate = dbApp.Doctor.MedicalSpeciality.SpecialityName;
                toReturn.Add(appModel);
            }
            
            return toReturn;
        }

        // POST api/appoiments
        public void Post([FromBody]string value)
        {
        }

        // PUT api/appoiments/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/appoiments/5
        public void Delete(int id)
        {
        }
    }
}
