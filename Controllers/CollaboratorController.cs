using FastDesafio.Interfaces;
using FastDesafio.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollaboratorController : ControllerBase
    {
        readonly ICollaboratorInterface _collaboratorInterface;

        public CollaboratorController(ICollaboratorInterface _collaboratorInterface)
        {
            this._collaboratorInterface = _collaboratorInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<CollaboratorModel>>>> GetAllCollaborators()
        {
            ResponseModel<List<CollaboratorModel>> response = await _collaboratorInterface.GetAllCollaborators();
            
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<CollaboratorModel>>> PostCollaborator(CollaboratorModel collaborator)
        {
            ResponseModel<CollaboratorModel> response = await _collaboratorInterface.PostCollaborator(collaborator);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<CollaboratorModel>>> GetOneCollaborators(int id)
        {
            ResponseModel<CollaboratorModel> response = await _collaboratorInterface.GetOneCollaborator(id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel<CollaboratorModel>>> PutCollaborator(CollaboratorModel updateCollaborator)
        {
            ResponseModel<CollaboratorModel> response = await _collaboratorInterface.PutCollaborator(updateCollaborator);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<CollaboratorModel>>> DeleteCollaborators(int id)
        {
            ResponseModel<CollaboratorModel> response = await _collaboratorInterface.DeleteCollaborator(id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
