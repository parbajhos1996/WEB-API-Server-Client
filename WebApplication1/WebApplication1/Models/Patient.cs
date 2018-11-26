using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Patient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string TajNumber { get; set; }
        public string Complaint { get; set; }

        public override bool Equals(object obj)
        {
            var patient = obj as Patient;
            return patient != null &&
                   FirstName == patient.FirstName &&
                   LastName == patient.LastName &&
                   Address == patient.Address &&
                   TajNumber == patient.TajNumber &&
                   Complaint == patient.Complaint;
        }

        public override int GetHashCode()
        {
            var hashCode = 1909415606;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TajNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Complaint);
            return hashCode;
        }
    }


}