using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.Dto.State
{
    public class StateDto
    {
        public int Id { get; set; }
        public virtual string StateName { get; set; }
    }
}
