using FastDesafio.Interfaces;
using FastDesafio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FastDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkshopController : ControllerBase
    {
        readonly IWorkshopInterface _workshopInterface;
        public WorkshopController(IWorkshopInterface _workshopInterface)
        {
            this._workshopInterface = _workshopInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<WorkshopModel>>>> GetAllWorkshops()
        {
            ResponseModel<List<WorkshopModel>> response = await _workshopInterface.GetAllWorkshops();

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<WorkshopModel>>> PostWorkshop( WorkshopModel workshop)
        {
            ResponseModel<WorkshopModel> response = await _workshopInterface.PostWorkshop(workshop);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<WorkshopModel>>> GetOneWorkshops(int id)
        {
            ResponseModel<WorkshopModel> response = await _workshopInterface.GetOneWorkshop(id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel<WorkshopModel>>> PutWorkshop(WorkshopModel updateWorkshop)
        {
            ResponseModel<WorkshopModel> response = await _workshopInterface.PutWorkshop(updateWorkshop);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<WorkshopModel>>> DeleteWorkshops(int id)
        {
            ResponseModel<WorkshopModel> response = await _workshopInterface.DeleteWorkshop(id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


    }
}
