using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.States
{
    [Table("States")]
    public class State: CommonDataModel
    {

        [Key]
        public int Id { get; set; }
        public virtual string StateName { get; set; }
    }
}
