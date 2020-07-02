using Abp.Application.Services;
using NurseryAngularApplication.Model.Dto.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.States.Dto
{
    public interface IStateRepository : IApplicationService
    {
        Task<List<StateDto>> GetAllState();

        Task<List<DistrictDto>> GetStateByDistrict(int id);

        Task<List<TehsilDto>> GetDistrictByTehsil(int id);
    }
}
