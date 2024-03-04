using FastDesafio.Data;
using FastDesafio.Interfaces;
using FastDesafio.Models;

namespace FastDesafio.Services
{
    public class CollaboratorService : ICollaboratorInterface
    {
        readonly DataContext _dataContext;
        public CollaboratorService(DataContext _dataContext)
        {
            this._dataContext = _dataContext;
        }

        public async Task<ResponseModel<List<CollaboratorModel>>> GetAllCollaborators()
        {
            ResponseModel<List<CollaboratorModel>> response = new ResponseModel<List<CollaboratorModel>>();
            try
            {
                response.Data = _dataContext.DbCollaborators.ToList();
                response.Message = "Lista de dados retornada";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<ResponseModel<CollaboratorModel>> PostCollaborator(CollaboratorModel collaborator)
        {
            ResponseModel<CollaboratorModel> response = new ResponseModel<CollaboratorModel>();
            try
            {
                if (collaborator == null)
                {
                    response.Message = "Dados não informados corretamente";
                    response.IsSuccess = false;

                    return response;
                }

                _dataContext.Add(collaborator);
                await _dataContext.SaveChangesAsync();

                response.Data = collaborator;
                response.Message = "Dados salvos no banco";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<ResponseModel<CollaboratorModel>> GetOneCollaborator(int id)
        {
            ResponseModel<CollaboratorModel> response = new ResponseModel<CollaboratorModel>();
            try
            {
                CollaboratorModel collaborator = _dataContext.DbCollaborators.FirstOrDefault(x => x.Id == id);
                if (collaborator == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Colaborador não existente";

                    return response;
                }
                response.Data = collaborator;
                response.Message = "Dado retornada";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<ResponseModel<CollaboratorModel>> PutCollaborator(CollaboratorModel updateCollaborator)
        {
            ResponseModel<CollaboratorModel> response = new ResponseModel<CollaboratorModel>();
            try
            {
                CollaboratorModel collaborator = _dataContext.DbCollaborators.FirstOrDefault(x => x.Id == updateCollaborator.Id);
                
                if (collaborator == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Colaborador não existente";

                    return response;
                }

                collaborator.Name = updateCollaborator.Name;

                await _dataContext.SaveChangesAsync();

                response.Data = updateCollaborator;
                response.Message = "Dado Modificado";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<ResponseModel<CollaboratorModel>> DeleteCollaborator(int id)
        {
            ResponseModel<CollaboratorModel> response = new ResponseModel<CollaboratorModel>();
            try
            {
                CollaboratorModel collaborator = _dataContext.DbCollaborators.FirstOrDefault(x => x.Id == id);
                
                if (collaborator == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Colaborador não existente";

                    return response;
                }

                _dataContext.DbCollaborators.Remove(collaborator);
                await _dataContext.SaveChangesAsync();

                response.Data = collaborator;
                response.Message = "Dado deletado";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

    }
}
