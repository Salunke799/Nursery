using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NurseryAngularApplication.Model.Sales.Dto;

namespace NurseryAngularApplication.Controllers
{
    [Route("api/Sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesRepository _salesRepository;

        public SalesController (ISalesRepository salesRepository )
        {
            _salesRepository = salesRepository;
        }


        [HttpGet]
        [Route("GetAllSales")]
        public async Task<ActionResult<IEnumerable<SalesListDto>>> GetAllSales (int? NurseryId)
        {
            return await _salesRepository.GetAllSales(NurseryId);
        }


        [HttpGet]
        [Route("GetEditSales")]
        public async Task<ActionResult<SalesListDto>> GetEditSales (int Id)
        {
            return await _salesRepository.EditSales(Id);
        }

        [HttpPost]
        [Route("AddSales")]
        public async Task<IActionResult> AddSales (CreateOrEditSaleDto input)
        {

            try
            {
                var postId = await _salesRepository.AddSales(input);
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
        [Route("DeleteSales")]
        public async Task<IActionResult> DeleteSales (int salesId )
        {
            int result = 0;

            if (salesId == 0)
            {
                return BadRequest();
            }

            try
            {
                result = await _salesRepository.DeleteSales(salesId);
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
        [Route("UpdateSales")]
        public async Task<IActionResult> UpdateSales(CreateOrEditSaleDto input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _salesRepository.UpdateSales(input);

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
