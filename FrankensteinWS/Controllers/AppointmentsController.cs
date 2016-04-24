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
        // GET api/appointments
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/appointments/5
        /* public List<AppointmentModel> Get(int id)
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
        }*/

        //GET api/appointments/5
        public List<AppointmentModel> Get(int id)
        {
            List<AppointmentModel> toReturn = new List<AppointmentModel>();

            List<Appointment> dbApps = new List<Appointment>();
            List<AppointmentDetail> dbAppsDetail = new List<AppointmentDetail>();

            dbApps = db.Appointments.Where(a => a.PersonId == id).ToList();
            
          
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Appointment, AppointmentModel>());
            var mapper = config.CreateMapper();

            foreach (var dbApp in dbApps)
            {
                AppointmentModel appModel = mapper.Map<AppointmentModel>(dbApp);
                appModel.Doctor = dbApp.Doctor.Name + ' ' + dbApp.Doctor.Surname;
                appModel.Speciality = dbApp.Doctor.MedicalSpeciality.SpecialityName;
                appModel.ClinicName = dbApp.Doctor.ClinicLocation.ClinicName;

                dbAppsDetail = db.AppointmentDetails.Where(b => b.AppointmentId == dbApp.AppointmentId).ToList();

                appModel.AppointmentDetailsList = new List<AppointmentDetailsModel>();
                var appDetailsConfig = new MapperConfiguration(cfg => cfg.CreateMap<AppointmentDetail, AppointmentDetailsModel>());
                var appDetailMapper = appDetailsConfig.CreateMapper();
                foreach (var dbAppDetail in dbAppsDetail)
                {
                    AppointmentDetailsModel detailModel = appDetailMapper.Map<AppointmentDetailsModel>(dbAppDetail);
                    appModel.AppointmentDetailsList.Add(detailModel);
                }
               
                toReturn.Add(appModel);
            }

            return toReturn;
        }

        // POST api/appointments
        public void Post([FromBody]string value)
        {
        }

        // PUT api/appointments/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/appointments/5
        public void Delete(int id)
        {
        }
    }
}
