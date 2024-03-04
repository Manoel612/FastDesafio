using FastDesafio.Interfaces;
using FastDesafio.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordController : ControllerBase
    {
        readonly IRecordInterface _recordInterface;
        public RecordController(IRecordInterface _recordInterface)
        {
            this._recordInterface = _recordInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<RecordModel>>>> GetAllRecords()
        {
            ResponseModel<List<RecordModel>> response = await _recordInterface.GetAllRecords();

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        /*
         * Se tem uma lista por workshop e não pode ser criada sem o workshop não faz sentido existir post
         * 
        [HttpPost]
        public async Task<ActionResult<ResponseModel<RecordModel>>> PostRecord(RecordModel record)
        {
            ResponseModel<RecordModel> response = await _recordInterface.PostRecord(record);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        */

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<RecordModel>>> GetOneRecord(int id)
        {
            ResponseModel<RecordModel> response = await _recordInterface.GetOneRecord(id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel<RecordModel>>> PutRecord(RecordModel updateRecord)
        {
            ResponseModel<RecordModel> response = await _recordInterface.PutRecord(updateRecord);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<RecordModel>>> DeleteRecord(int id)
        {
            ResponseModel<RecordModel> response = await _recordInterface.DeleteRecord(id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("{id}/AddCollaborator")]
        public async Task<ActionResult<ResponseModel<CollaboratorModel>>> AddCollaborator(int collaboratorId, int id)
        {
            ResponseModel<CollaboratorModel> response = await _recordInterface.AddCollaborator(collaboratorId, id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("{id}/RemoveCollaborator")]
        public async Task<ActionResult<ResponseModel<CollaboratorModel>>> RemoveCollaborator(int collaboratorId, int id)
        {
            ResponseModel<CollaboratorModel> response = await _recordInterface.RemoveCollaborator(collaboratorId, id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("GetAllCollaboratorsInWorkshop/{workshopId}")]
        public async Task<ActionResult<ResponseModel<List<CollaboratorModel>>>> GetAllCollaboratorsInWorkshop(int workshopId)
        {
            ResponseModel<List<CollaboratorModel>> response = await _recordInterface.GetAllCollaboratorsInWorkshop(workshopId);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
