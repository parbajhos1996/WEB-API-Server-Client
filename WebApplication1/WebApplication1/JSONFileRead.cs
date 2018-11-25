using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1
{
    public class JSONFileRead
    {
        public static IList<Patient> ReadFromJsonFile()
        {
            IList<Patient> PatientList = new List<Patient>();
            TextReader reader = null;
            try
            {
                string SaveFile = (string) HttpContext.GetGlobalResourceObject("file", "patient.txt");
                reader = new StreamReader(SaveFile);
                string line;
                while ((line = reader.ReadLine()) != null) {
                    PatientList.Add(JsonConvert.DeserializeObject<Patient>(line));
                }
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return PatientList;
        }
    }
}