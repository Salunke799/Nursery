using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.States
{
    public class District : CommonDataModel
    {
        [Key]
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public int? StateId { get; set; }
        public State State { get; set; }

    }
}
