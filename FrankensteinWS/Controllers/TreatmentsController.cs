using FrankensteinWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FrankensteinWS.Controllers
{
    public class TreatmentsController : BaseController
    {
        // GET api/treatments
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/treatments/5
        public List<AppointmentTreatment> Get(int id)
        {
            List<AppointmentTreatment> toReturn = new List<AppointmentTreatment>();
            List<TreatmentDetail> dbTreatmentDetails = new List<TreatmentDetail>();
            List<Drug> dbDrugs = new List<Drug>();
            List<Appointment> dbApps = new List<Appointment>();
            
            int TreatmentId;

            dbDrugs = db.Drugs.ToList();
            dbApps = db.Appointments.Where(a => a.PersonId == id).OrderByDescending(a => a.AppointmentDate).ToList();

            foreach(var dbApp in dbApps)
            {
                AppointmentTreatment appTreatment = new AppointmentTreatment();
                appTreatment.AppointmentId = dbApp.AppointmentId;
                appTreatment.TreatmentDate = dbApp.AppointmentDate;
                appTreatment.Doctor = dbApp.Doctor.Name + ' ' + dbApp.Doctor.Surname;
                appTreatment.Speciality = dbApp.Doctor.MedicalSpeciality.SpecialityName;
                appTreatment.Diagnostic = db.AppointmentDetails.Where(a => a.AppointmentId == dbApp.AppointmentId).Select(a => a.Diagnostic).FirstOrDefault();
                appTreatment.TreatmentList = new List<TreatmentDetailsModel>();

                TreatmentId = db.Treatments.Where(t => t.AppointmentId == dbApp.AppointmentId).Select(t => t.TreatmentId).FirstOrDefault();
                dbTreatmentDetails = db.TreatmentDetails.Where(d => d.TreatmentId == TreatmentId).ToList();

                foreach(var dbTreat in dbTreatmentDetails)
                {
                    TreatmentDetailsModel treatmentModel = new TreatmentDetailsModel();
                    treatmentModel.DrugName = dbDrugs.First(t => t.DrugId == dbTreat.DrugId).Name;
                    treatmentModel.Tablets = Convert.ToInt32(dbTreat.Tablets);
                    treatmentModel.Dose = Convert.ToInt32(dbTreat.Dose);
                    treatmentModel.Periodicity = Convert.ToInt32(dbTreat.Periodicity);
                    treatmentModel.PeriodicityType = Convert.ToInt32(dbTreat.PeriodicityType);

                    appTreatment.TreatmentList.Add(treatmentModel);
                }

                if(appTreatment.TreatmentList.Count != 0)
                {
                    toReturn.Add(appTreatment);
                }
            }
            return toReturn;
        }

        // POST api/treatments
        public void Post([FromBody]string value)
        {
        }

        // PUT api/treatments/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/treatments/5
        public void Delete(int id)
        {
        }
    }
}
