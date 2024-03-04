using FastDesafio.Data;
using FastDesafio.Interfaces;
using FastDesafio.Models;
using Microsoft.EntityFrameworkCore;

namespace FastDesafio.Services
{
    public class RecordService : IRecordInterface
    {
        readonly DataContext _dataContext;

        public RecordService(DataContext _dataContext)
        {
            this._dataContext = _dataContext;
            
        }

        public async Task<ResponseModel<List<RecordModel>>> GetAllRecords()
        {
            ResponseModel<List<RecordModel>> response = new ResponseModel<List<RecordModel>>();
            try
            {
                response.Data = await _dataContext.DbRecord.ToListAsync();
                response.Message = "Lista de dados retornada";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;

        }
        //
        /*
        public async Task<ResponseModel<RecordModel>> PostRecord(RecordModel record)
        {
            ResponseModel<RecordModel> response = new ResponseModel<RecordModel>();
            try
            {
                if (record == null)
                {
                    response.Message = "Dados não informados corretamente";
                    response.IsSuccess = false;

                    return response;
                }

                RecordModel recordExistent = _dataContext.DbRecord.FirstOrDefault(x => x.Id == record.Id);
                if ( recordExistent != null )
                {
                    response.Message = "Já existe uma ata de presença para esse Workshop";
                    response.IsSuccess = false;
                    return response;
                }

                WorkshopModel workshopExistent = await _dataContext.DbWorkshop.FirstAsync(x => x.Id == record.WorkshopId);
                response.Message = "workshop: " + workshopExistent;
                if (recordExistent == null)
                {
                    response.Message = ("Workshop inexistente " + workshopExistent);
                    response.IsSuccess = false;
                    return response;
                }

                _dataContext.Add(record);
                await _dataContext.SaveChangesAsync();

                response.Data = record;
                //response.Message = "Dados salvos no banco";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }*/

        public async Task<ResponseModel<RecordModel>> GetOneRecord(int id)
        {
            ResponseModel<RecordModel> response = new ResponseModel<RecordModel>();
            try
            {
                RecordModel record = _dataContext.DbRecord.FirstOrDefault(x => x.Id == id);

                if (record == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Ata de presença não existente";

                    return response;
                }
                response.Message = "Dado retornada";
                response.Data = record;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<ResponseModel<RecordModel>> PutRecord(RecordModel updateRecord)
        {
            ResponseModel<RecordModel> response = new ResponseModel<RecordModel>();
            try
            {
                RecordModel record = _dataContext.DbRecord.AsNoTracking().FirstOrDefault(x => x.Id == updateRecord.Id);

                if (record == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Ata de presença não existente";

                    return response;
                }

                record.WorkshopId = updateRecord.WorkshopId;
                record.CollaboratorIds = updateRecord.CollaboratorIds;

                await _dataContext.SaveChangesAsync();

                response.Data = updateRecord;
                response.Message = "Dado modificado";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
        
        public async Task<ResponseModel<RecordModel>> DeleteRecord(int id)
        {
            ResponseModel<RecordModel> response = new ResponseModel<RecordModel>();
            try
            {
                RecordModel record = _dataContext.DbRecord.FirstOrDefault(x => x.Id == id);

                if (record == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Lista de presença não existente";

                    return response;
                }

                _dataContext.DbRecord.Remove(record);
                await _dataContext.SaveChangesAsync();

                response.Message = "Dado deletado";
                response.Data = record;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }


        public async Task<ResponseModel<CollaboratorModel>> AddCollaborator(int collaboratorId, int recordId)
        {
            ResponseModel<CollaboratorModel> response = new ResponseModel<CollaboratorModel>();
            try
            {
                RecordModel record = _dataContext.DbRecord.FirstOrDefault(x => x.Id == recordId);
                if (record == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Ata de presença inexistente";
                    return response;
                }
                if (record.CollaboratorIds.IndexOf(collaboratorId) != -1)
                {
                    response.IsSuccess = false;
                    response.Message = "Colaborador já incluso na ata de presença";
                    return response;
                }

                CollaboratorModel collaborator = _dataContext.DbCollaborators.FirstOrDefault(x => x.Id == collaboratorId);
                if (collaborator == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Colaborador inexistente";
                    return response;
                }

                record.CollaboratorIds.Add(collaboratorId);
                
                await _dataContext.SaveChangesAsync();

                response.Message = "Colaborador adicionado a Ata de presença";
                response.Data = collaborator;
            }   
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;

        }

        public async Task<ResponseModel<CollaboratorModel>> RemoveCollaborator(int collaboratorId, int recordId)
        {
            ResponseModel<CollaboratorModel> response = new ResponseModel<CollaboratorModel>();
            try
            {
                RecordModel record = _dataContext.DbRecord.FirstOrDefault(x => x.Id == recordId);
                if (record == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Ata de presença inexistente";
                    return response;
                }

                CollaboratorModel collaborator = _dataContext.DbCollaborators.FirstOrDefault(x => x.Id == collaboratorId);
                if (collaborator == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Colaborador inexistente";
                    return response;
                }

                record.CollaboratorIds.Remove(collaboratorId);

                await _dataContext.SaveChangesAsync();

                response.Message = "Colaborador removido da Ata de presença";
                response.Data = collaborator;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<ResponseModel<List<CollaboratorModel>>> GetAllCollaboratorsInWorkshop( int workshopId)
        {
            ResponseModel<List<CollaboratorModel>> response = new ResponseModel<List<CollaboratorModel>>();
            try
            {
                List<int> collaboratorsIds = _dataContext.DbRecord.First( x => x.WorkshopId == workshopId).CollaboratorIds;
                List<CollaboratorModel> collaborators = _dataContext.DbCollaborators.Where(x => collaboratorsIds.Contains(x.Id)).ToList();
                //List<CollaboratorModel> collaborators = _dataContext.DbCollaborators.First(x => x.Id == );
                
                response.Data = collaborators;
                response.Message = "Lista de dados retornada";
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
