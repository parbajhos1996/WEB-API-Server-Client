using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PatientController : ApiController
    {
        private static IList<Patient> PatientList = new List<Patient>();

        public IList<Patient> Get()
        {
            Console.WriteLine("asdasdasdasda");
            return PatientList;
        }

        public Patient Get(int id)
        {
            if (id >= 0 && id < PatientList.Count)
            {
                return PatientList[id];
            }

            return null;
        }

        public void Post([FromBody]Patient patient)
        {
            if (PatientList.Contains(patient))
            {
                PatientList.Remove(patient);
            }
            else if (patient != null)
            {
                PatientList.Add(patient);
            }
        }



    }
}