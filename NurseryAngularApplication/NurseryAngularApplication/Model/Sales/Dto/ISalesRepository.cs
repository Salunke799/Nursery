using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.Sales.Dto
{
    public interface ISalesRepository : IApplicationService
    {
        public Task<List<SalesListDto>> GetAllSales(int? Id);
        Task<int> AddSales (CreateOrEditSaleDto input);
        Task<SalesListDto> EditSales(int salesId );
        Task<int> DeleteSales (int salesId );
        Task UpdateSales(CreateOrEditSaleDto input);
    }
}
