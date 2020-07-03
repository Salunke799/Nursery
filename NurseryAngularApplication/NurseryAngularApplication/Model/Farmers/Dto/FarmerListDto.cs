using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.Farmers.Dto
{
    public class FarmerListDto : Entity
    {
        public string Nursery { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string VillageName { get; set; }
        public string GenderType { get; set; }
        public string EducationType { get; set; }
        public int? StateId { get; set; }
        public string State { get; set; }
        public int? DistrictId { get; set; }
        public string District { get; set; }
        public int? TehsilId { get; set; }
        public string Tehsil { get; set; }
    }
}
