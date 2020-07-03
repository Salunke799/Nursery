using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.Farmers.Dto
{
    public interface IFarmerRepository : IApplicationService
    {
        public Task<List<FarmerListDto>> GetAllFarmer(int? NurseryId);
        Task<int> AddFarmer(CreateorEditFarmer input);
        Task<FarmerListDto> EditFarmer(int FarmerId);
        Task<int> DeleteFarmer(int FarmerId);
        Task UpdateFarmer(CreateorEditFarmer input);
    }
}
