using Microsoft.EntityFrameworkCore;
using NurseryAngularApplication.Model.Dto.State;
using NurseryAngularApplication.Model.States;
using NurseryAngularApplication.Model.States.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryAngularApplication.Model.AppService
{
    public class StateRepository : NurseryAppServiceBase,IStateRepository
    {

        private readonly NursaryContext _nursaryContext;
        public StateRepository(NursaryContext nursaryContext)
        {
            _nursaryContext = nursaryContext;
        }
        public async Task<List<StateDto>> GetAllState()
        {
            var states = new List<StateDto>();
            try
            {
                states = await (from b in _nursaryContext.States
                                select new StateDto()
                                {
                                    Id = b.Id,
                                    StateName = b.StateName
                                }).ToListAsync();
                return states;


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<DistrictDto>> GetStateByDistrict  (int id)
        {
            var district  = new List<DistrictDto>();
          
            if (id > 0)
            {
                district = await (from b in _nursaryContext.Districts
                                where (b.StateId == id)
                                select new DistrictDto()
                                {
                                    Id = b.Id,
                                    DistrictName = b.DistrictName
                                }).ToListAsync();

                return district;
            }
            return district;
        }

        public async Task<List<TehsilDto>> GetDistrictByTehsil(int id)
        {
            var tehsil  = new List<TehsilDto>();

            if (id > 0)
            {
                tehsil = await (from b in _nursaryContext.Tehsils
                                  where (b.DistrictId == id)
                                  select new TehsilDto()
                                  {
                                      Id = b.Id,
                                      TehsilName = b.TehsilName
                                  }).ToListAsync();

                return tehsil;
            }
            return tehsil;
        }

    }
}
