using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.States
{
    public class Tehsil : CommonDataModel
    {
        [Key]
        public int Id { get; set; }
        public string TehsilName { get; set; }
        public int? DistrictId { get; set; }
        public District District { get; set; }
    }
}
