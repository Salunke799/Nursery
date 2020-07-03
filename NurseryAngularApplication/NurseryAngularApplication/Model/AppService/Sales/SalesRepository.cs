using Abp.Application.Services;
using Abp.Collections.Extensions;
using Microsoft.EntityFrameworkCore;
using NurseryAngularApplication.Model.Sales;
using NurseryAngularApplication.Model.Sales.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.AppService.Sales
{
    public class SalesRepository : ApplicationService, ISalesRepository
    {
        private readonly NursaryContext _nursaryContext;

        public  SalesRepository(NursaryContext nursaryContext)
        {
            _nursaryContext = nursaryContext;
        }
        public async Task<int> AddSales(CreateOrEditSaleDto input)
        {
            SalesDetail cd = new SalesDetail();
            cd.NurseryId = input.NurseryId;
            cd.FarmerId = input.FarmerId;
            cd.ProductName = input.ProductName;
            cd.Cost = input.Cost;
            cd.Advanceamount = input.Advanceamount;
            cd.Date = input.Date;
            cd.Quantity = input.Quantity;
            cd.Total = input.Total;
            cd.CreationDate = DateTime.Now;
            cd.IsDeleted = false;
            cd.GrandTotal = input.GrandTotal;           
            await _nursaryContext.SalesDetails.AddAsync(cd);
            await _nursaryContext.SaveChangesAsync();

            return input.Id;
        }

        public async Task<int> DeleteSales(int salesId)
        {

            int result = 0;
            var farmer = await _nursaryContext.SalesDetails.FirstOrDefaultAsync(x => x.Id == salesId);
            if (farmer != null)
            {
                farmer.IsDeleted = true;
                _nursaryContext.SalesDetails.Update(farmer);
                result = await _nursaryContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<SalesListDto> EditSales(int salesId)
        {
            var query = new SalesListDto();
            try
            {
                query = await(from b in _nursaryContext.SalesDetails.Where(x => x.IsDeleted == false && x.Id==salesId).
                          Include(x => x.Nursery).Include(x => x.Farmer)                        
                         select new SalesListDto()
                         {
                             Id = b.Id,
                             NurseryId = b.NurseryId,
                             FarmerId = b.FarmerId,
                             Nursery = b.Nursery.NurseryName,
                             ProductName = b.ProductName,
                             Farmer = b.Farmer.FirstName + " " + b.Farmer.LastName,
                             Cost = b.Cost,
                             Advanceamount = b.Advanceamount,
                             Quantity = b.Quantity,
                             Total = b.Total,
                             GrandTotal = b.GrandTotal,
                             Date = b.Date,
                         }).FirstOrDefaultAsync(); 

                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<SalesListDto>> GetAllSales(int? Id)
        {
            var query = new List<SalesListDto>();
            try
            {
                query = (from b in _nursaryContext.SalesDetails.Where(x => x.IsDeleted == false).
                            Include(x => x.Nursery).Include(x=>x.Farmer)                           
                            .WhereIf(Id != null, x => x.NurseryId == Id)
                         select new SalesListDto()
                         {
                             Id = b.Id,
                             NurseryId=b.NurseryId,
                             FarmerId=b.FarmerId,
                             Nursery = b.Nursery.NurseryName,
                             ProductName = b.ProductName,
                             Farmer = b.Farmer.FirstName+" "+b.Farmer.LastName,
                             Cost = b.Cost,
                             Advanceamount = b.Advanceamount,
                             Quantity = b.Quantity,
                             Total = b.Total,
                             GrandTotal = b.GrandTotal,
                             Date = b.Date,                            
                          }).ToList();

                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateSales(CreateOrEditSaleDto input)
        {
            var getdata = _nursaryContext.SalesDetails.Where(x => x.Id == input.Id).FirstOrDefault();
            getdata.NurseryId = input.NurseryId;
            getdata.FarmerId = input.FarmerId;
            getdata.ProductName = input.ProductName;
            getdata.Cost = input.Cost;
            getdata.Quantity = input.Quantity;
            getdata.Total = input.Total;
            getdata.Advanceamount = input.Advanceamount;
            getdata.Date = input.Date;           
            _nursaryContext.SalesDetails.Update(getdata);
            //Commit the transaction
            await _nursaryContext.SaveChangesAsync();
        }
    }
}
