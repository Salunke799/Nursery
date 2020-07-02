using NurseryAngularApplication.Model.Nurserys;
using NurseryAngularApplication.Model.States;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.Employee
{
    public class EmployeeDetail : CommonDataModel
    {
        [Key]
        public int Id { get; set; } 

        public int? NurseryId { get; set; }
        public Nursery Nursery { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public DateTime? DateofBirth { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }
        public string VillageName { get; set; }
        public GenderType GenderType { get; set; }

        public EducationType EducationType { get; set; }

        public int? StateId { get; set; }
        public State State { get; set; }

        public int? DistrictId { get; set; }
        public District District { get; set; }

        public int? TehsilId { get; set; }
        public Tehsil Tehsil { get; set; }

    }

    public enum GenderType
    {
        Male = 1,
        Female = 2
    }

    public enum EducationType
    {
        PostGraduation = 1,
        Graduation = 2,
        HSC = 3,
        SSC = 4,
        Other = 5
    }
}
