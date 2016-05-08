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
    public class ScheduleController : BaseController
    {
        // GET api/schedule
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/schedule/5
        /*public List<DateTime> Get(int id)
        {
            
        }*/

        // POST api/schedule
        public List<DateTime> Post(ScheduleModel schedule)
        {
            List<DateTime> allDates = new List<DateTime>();
            List<DateTime> availableDates = new List<DateTime>();

            for (int i = 9; i <= 21; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    allDates.Add(new DateTime(schedule.RequestDate.Year, schedule.RequestDate.Month, schedule.RequestDate.Day, i, j * 30, 0));
                }
            }

            List<DateTime> takenDates = new List<DateTime>();
            List<Appointment> apps = new List<Appointment>();

            apps = db.Appointments.Where(a => a.DoctorId == schedule.DoctorId && a.AppointmentDate.Year == schedule.RequestDate.Year 
                                                            && a.AppointmentDate.Month == schedule.RequestDate.Month && a.AppointmentDate.Day == schedule.RequestDate.Day).ToList();

            foreach (var a in apps)
            {
                takenDates.Add(a.AppointmentDate);
            }

            foreach (var alldate in allDates)
            {
                bool dateExists = false;
                foreach (var takendate in takenDates)
                {
                    if (alldate.Equals(takendate))
                    {
                        dateExists = true;
                    }
                }

                if(!dateExists)
                {
                    availableDates.Add(alldate);
                }
            }

            return availableDates;
           
        }

        // PUT api/schedule/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/schedule/5
        public void Delete(int id)
        {
        }
    }
}
