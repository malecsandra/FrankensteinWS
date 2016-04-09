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
    public class DoctorsController : BaseController
    {
        // GET api/doctor
       
        // GET api/doctor/5
        public List<DoctorModel> Get()
        {
            List<DoctorModel> toReturn = new List<DoctorModel>(); // Create a list that contains the results we are about to send

            List<Doctor> dbDoctors = db.Doctors.ToList(); // Get all the doctors from the database

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorModel>()); // Create a mapper config to convert from DB-Doctors to return doctors
            var mapper = config.CreateMapper(); // Create the mapper using the above config

            // Configure each doctor that we get from the DB
            foreach (var doc in dbDoctors) // For every doctor that we got from the database
            {
                DoctorModel docModel = mapper.Map<DoctorModel>(doc); // Create a doctor model that we are going to add to the list that we will be returning

                var configS = new MapperConfiguration(cfg => cfg.CreateMap<MedicalSpeciality, SpecialityModel>()); // Create a mapper config to convert the DB-Speciality to a SpecialityModel
                var mapperS = configS.CreateMapper(); // Create a new mapper using the above convig

                docModel.SpecialityModel = mapperS.Map<SpecialityModel>(doc.MedicalSpeciality); // Convert the DB-Doctor's DB-Speciality to a SpecialityModel and set it in our Doctor model

                var configC = new MapperConfiguration(cfg => cfg.CreateMap<ClinicLocation, ClinicModel>()); // Create a mapper config to convert the DB-ClinicLocation to a ClinicModel
                var mapperC = configC.CreateMapper(); // Create a new mapper using the above config

                docModel.ClinicModel = mapperC.Map<ClinicModel>(doc.ClinicLocation); // Convert the DB-ClinicLocation to a ClinicModel and set it in our Doctor model

                toReturn.Add(docModel); // Add the newly configured doctor to our list of doctors to return
            }

            return toReturn; // Return the newly created list
        }

        // POST api/doctor
        public void Post([FromBody]string value)
        {
        }

        // PUT api/doctor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/doctor/5
        public void Delete(int id)
        {
        }
    }
}
