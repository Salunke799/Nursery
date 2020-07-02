using NurseryAngularApplication.Model.Farmers;
using NurseryAngularApplication.Model.Nurserys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.Sales
{
    public class SalesDetail: CommonDataModel
    {
        [Key]
        public int Id { get; set; }
        public int? NurseryId  { get; set; }
        public Nursery Nursery { get; set; }

        public int? FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        public string ProductName { get; set; }

        public int? Quantity { get; set; }

        public int? Cost  { get; set; }

        public int? Total { get; set; }

        public int? Advanceamount { get; set; }

        public DateTime? Date { get; set; }

        public int? GrandTotal { get; set; }

    }
}
