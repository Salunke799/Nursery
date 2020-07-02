using NurseryAngularApplication.Model.States;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.Nurserys
{
    public class Nursery : CommonDataModel
    {
        [Key]
        public int Id { get; set; }
        public string NurseryName { get; set; }
        public string ContactNumber { get; set; }

        public string VilageName { get; set; }

        public int? StateId { get; set; }
        public State State { get; set; }

        public int? DistrictId { get; set; }
        public District District { get; set; }

        public int? TehsilId { get; set; }
        public Tehsil Tehsil { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime? StartDate { get; set; }

        public string EmailId { get; set; }

    }
}
