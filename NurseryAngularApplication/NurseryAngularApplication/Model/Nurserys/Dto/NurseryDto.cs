using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.Nurserys.Dto
{
    public class NurseryDto : Entity
    {
        public string NurseryName { get; set; }
        public string ContactNumber { get; set; }

        public string VilageName { get; set; }

        public int? StateId { get; set; }

        public int? DistrictId { get; set; }

        public int? TehsilId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime? StartDate { get; set; }
        public string EmailId { get; set; }
    }
}
