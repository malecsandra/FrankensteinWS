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
    public class ClinicsController : BaseController
    {
        // GET api/clinics/5
        public List<ClinicModel> Get()
        {
            List<ClinicModel> toReturn = new List<ClinicModel>();

            List<ClinicLocation> dbClinics = db.ClinicLocations.ToList();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClinicLocation, ClinicModel>());
            var mapper = config.CreateMapper();

            foreach (var dbClinic in dbClinics)
            {
                ClinicModel clinicModel = mapper.Map<ClinicModel>(dbClinic);
                toReturn.Add(clinicModel);
            }

            return toReturn; // Return the newly created list
        }

        // POST api/clinics
        public void Post([FromBody]string value)
        {
        }

        // PUT api/clinics/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/clinics/5
        public void Delete(int id)
        {
        }
    }
}
