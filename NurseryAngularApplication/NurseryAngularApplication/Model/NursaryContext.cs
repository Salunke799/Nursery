using Microsoft.EntityFrameworkCore;
using NurseryAngularApplication.Model.Employee;
using NurseryAngularApplication.Model.Farmers;
using NurseryAngularApplication.Model.LoginDetails;
using NurseryAngularApplication.Model.Nurserys;
using NurseryAngularApplication.Model.Sales;
using NurseryAngularApplication.Model.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model
{
    public class NursaryContext : DbContext
    {
        public NursaryContext(DbContextOptions<NursaryContext> options)
         : base(options)
        {

        }      
        public virtual DbSet<State> States { get; set; }

        public virtual DbSet<District> Districts { get; set; }

        public virtual DbSet<Tehsil> Tehsils  { get; set; }

        public virtual DbSet<Nursery> Nurserys { get; set; }

        public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }

        public virtual DbSet<Farmer> Farmers { get; set; }

        public virtual DbSet<Login> Logins { get; set; }

        public virtual DbSet<SalesDetail> SalesDetails { get; set; }
    }
}
