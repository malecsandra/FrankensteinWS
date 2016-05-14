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
    public class MedicalTestsController : BaseController
    {
        // GET api/medicaltests
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/medicaltests/5
        public List<AppointmentTestSet> Get(int id)
        {
            List<AppointmentTestSet> toReturn = new List<AppointmentTestSet>();
            List<MedicalTest> dbMedicalTests = new List<MedicalTest>();
            List<Test> dbTests = new List<Test>();
            List<Appointment> dbApps = new List<Appointment>();

            dbTests = db.Tests.ToList();
            dbApps = db.Appointments.Where(a => a.PersonId == id).OrderByDescending(a => a.AppointmentDate).ToList();

            foreach (var dbApp in dbApps)
            {
                AppointmentTestSet appTestSet = new AppointmentTestSet();
                appTestSet.AppointmentId = dbApp.AppointmentId;
                appTestSet.MedicalTestDate = dbApp.AppointmentDate;
                appTestSet.Doctor = dbApp.Doctor.Name + ' ' + dbApp.Doctor.Surname;
                appTestSet.Speciality = dbApp.Doctor.MedicalSpeciality.SpecialityName;
                appTestSet.Diagnostic = db.AppointmentDetails.Where(a => a.AppointmentId == dbApp.AppointmentId).Select(a => a.Diagnostic).FirstOrDefault();
                appTestSet.TestList = new List<MedicalTestModel>();

                dbMedicalTests = db.MedicalTests.Where(m => m.AppointmentId == dbApp.AppointmentId).ToList();

                foreach (var dbTest in dbMedicalTests)
                {
                    MedicalTestModel appModel = new MedicalTestModel();
                    appModel.TestName = dbTests.First(t => t.TestId == dbTest.TestId).Name;
                    appModel.CategoryName = dbTests.First(t => t.TestId == dbTest.TestId).Category;
                    appModel.MinValue = dbTests.First(t => t.TestId == dbTest.TestId).MinValue;
                    appModel.MaxValue = dbTests.First(t => t.TestId == dbTest.TestId).MaxValue;
                    appModel.UnitMeasure = dbTests.First(t => t.TestId == dbTest.TestId).UnitMeasure;
                    appModel.Result = dbTest.Result;

                    appTestSet.TestList.Add(appModel); 
    
                }

                if (appTestSet.TestList.Count != 0)
                {
                    toReturn.Add(appTestSet);
                }
            }
            
            return toReturn;
        }

        // POST api/medicaltests
        public void Post([FromBody]string value)
        {
        }

        // PUT api/medicaltests/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/medicaltests/5
        public void Delete(int id)
        {
        }
    }
}
