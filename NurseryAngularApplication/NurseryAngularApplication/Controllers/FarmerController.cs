using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NurseryAngularApplication.Model.Farmers.Dto;

namespace NurseryAngularApplication.Controllers
{
    [Route("api/Farmer")]
    [ApiController]
    public class FarmerController : ControllerBase
    {
        private readonly IFarmerRepository _farmerRepository;

        public FarmerController(IFarmerRepository farmerRepository)
        {
            _farmerRepository = farmerRepository;
        }


        [HttpGet]
        [Route("GetAllFarmer")]
        public async Task<ActionResult<IEnumerable<FarmerListDto>>> GetAllFarmers (int? NurseryId)
        {
            return await _farmerRepository.GetAllFarmer(NurseryId);
        }


        [HttpGet]
        [Route("GetEditFarmer")]
        public async Task<ActionResult<FarmerListDto>> GetEditFarmer(int Id)
        {
            return await _farmerRepository.EditFarmer(Id);
        }

        [HttpPost]
        [Route("AddFarmer")]
        public async Task<IActionResult> AddFarmers(CreateorEditFarmer input)
        {

            try
            {
                var postId = await _farmerRepository.AddFarmer(input);
                if (postId > 0)
                {
                    return Ok(postId);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }

        [HttpDelete]
        [Route("DeleteFarmer")]
        public async Task<IActionResult> DeleteFarmers(int farmerId)
        {
            int result = 0;

            if (farmerId == 0)
            {
                return BadRequest();
            }

            try
            {
                result = await _farmerRepository.DeleteFarmer(farmerId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("UpdateFarmer")]
        public async Task<IActionResult> UpdateFarmers(CreateorEditFarmer input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _farmerRepository.UpdateFarmer(input);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}
