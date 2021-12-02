using Core.Utilities.Result.ComplexTypes;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NufusController:ControllerBase
    {
        INufusService nufusService;

        public NufusController(INufusService nufusService)
        {
            this.nufusService = nufusService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var nufuslar = await nufusService.GetAll();
            if (nufuslar.ResultStatus == ResultStatus.Success)
            {
                return Ok(nufuslar.Data);
            }
            return BadRequest(nufuslar.Message);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var nufus = await nufusService.Get(id);
            if (nufus.ResultStatus == ResultStatus.Success)
            {
                return Ok(nufus.Data);
            }
            return BadRequest(nufus.Message);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Nufus nufus)
        {
            await nufusService.Add(nufus);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(Nufus nufus)
        {
            var updateNufus = await nufusService.Update(nufus);
            if(updateNufus.ResultStatus == ResultStatus.Success)
            {
                return Ok(updateNufus);
            }
            return BadRequest(updateNufus.Message);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteNufus = await nufusService.Delete(id);
            if(deleteNufus.ResultStatus == ResultStatus.Success)
            {
                return Ok(deleteNufus);
            }
            return BadRequest(deleteNufus.Message);
        }
    }
}
