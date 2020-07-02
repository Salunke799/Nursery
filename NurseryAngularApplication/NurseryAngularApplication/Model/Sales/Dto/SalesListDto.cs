using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.Sales.Dto
{
    public class SalesListDto: Entity
    {
        public int? NurseryId { get; set; }
        public string Nursery { get; set; }

        public int? FarmerId { get; set; }
        public string Farmer { get; set; }

        public string ProductName { get; set; }

        public int? Quantity { get; set; }

        public int? Cost { get; set; }

        public int? Total { get; set; }

        public int? Advanceamount { get; set; }

        public DateTime? Date { get; set; }

        public int? GrandTotal { get; set; }
    }
}
