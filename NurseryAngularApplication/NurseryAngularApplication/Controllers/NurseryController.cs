using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NurseryAngularApplication.Model.Nurserys.Dto;

namespace NurseryAngularApplication.Controllers
{
    [Route("/api/Nursery")]
    [ApiController]
    public class NurseryController : ControllerBase
    {

        private readonly INurseryRepository _nurseryRepository;

        public NurseryController(INurseryRepository nurseryRepository)
        {
            _nurseryRepository = nurseryRepository;
        }

        [HttpGet]
        [Route("GetAllNursery")]
        public async Task<ActionResult<IEnumerable<NurseryListDto>>> GetAllNursery()
        {
            return await _nurseryRepository.GetAllNursey();
        }


        [HttpGet]
        [Route("GetEditNursery")]
        public async Task<ActionResult<NurseryListDto>> GetEditNursery(int Id)
        {
            return await _nurseryRepository.NurseryEdit(Id);
        }
        // GET: api/Nursery
        [HttpPost]
        [Route("AddNursery")]
        public async Task<IActionResult> AddNurserys(NurseryDto input)
        {

            try
            {
                var postId = await _nurseryRepository.AddNursery(input);
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
        [Route("DeleteNursery")]
        public async Task<IActionResult> DeleteNursery(int? NursaryId)
        {
            int result = 0;

            if (NursaryId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _nurseryRepository.DeleteNursery(NursaryId);
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

        [HttpGet]
        [Route("UpdateNursery")]
        public async Task<IActionResult> UpdatePost(NurseryDto input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _nurseryRepository.UpdateNursery(input);

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
