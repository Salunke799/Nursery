using Abp.Domain.Entities;
using NurseryAngularApplication.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.Farmers.Dto
{
    public class CreateorEditFarmer : Entity
    {
        public int? NurseryId { get; set; }
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
        public int? DistrictId { get; set; }
        public int? TehsilId { get; set; }
    }
}
