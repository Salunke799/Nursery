using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NurseryAngularApplication.Model.Dto.State;
using NurseryAngularApplication.Model.States.Dto;

namespace NurseryAngularApplication.Controllers
{
    [Route("api/States")]
    [ApiController]
    public class StateController : ControllerBase
    {
      
            private readonly IStateRepository _staterepository;

            public StateController(IStateRepository staterepository)
            {
                _staterepository = staterepository;
            }

            [HttpGet]
            [Route("GetAllState")]
            public async Task<ActionResult<IEnumerable<StateDto>>> GetAllState()
            {
                return await _staterepository.GetAllState();
            }

            [HttpGet]
            [Route("GetStateByDistrict")]
            public async Task<ActionResult<IEnumerable<DistrictDto>>> GetStateByDistrict (int id)
            {
                return await _staterepository.GetStateByDistrict(id);
            }

           [HttpGet]
           [Route("GetDistrictByTehsil")]
           public async Task<ActionResult<IEnumerable<TehsilDto>>> GetDistrictByTehsil (int id)
           {
            return await _staterepository.GetDistrictByTehsil(id);
           }

            

    }
    
}
