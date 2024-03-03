using Azure;
using FastDesafio.Data;
using FastDesafio.Interfaces;
using FastDesafio.Models;

namespace FastDesafio.Services
{  
    public class WorkshopService : IWorkshopInterface
    {
        readonly DataContext _dataContext;
        public WorkshopService(DataContext _dataContext)
        {
            this._dataContext = _dataContext;
        }

      public async Task<ResponseModel<List<WorkshopModel>>> GetAllWorkshops()
        {
            ResponseModel<List<WorkshopModel>> response = new ResponseModel<List<WorkshopModel>>();
            try
            {
                response.Data = _dataContext.DbWorkshop.ToList();
                response.Message = "Lista de dados retornada";
            } catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
  
        public async Task<ResponseModel<WorkshopModel>> PostWorkshop( WorkshopModel workshop )
        {
            ResponseModel<WorkshopModel> response = new ResponseModel<WorkshopModel>();
            try
            {
                if ( workshop == null )
                {
                    response.Message = "Dados não informados corretamente";
                    response.IsSuccess = false;

                    return response;
                }

                _dataContext.Add(workshop);
                await _dataContext.SaveChangesAsync();

                response.Data = workshop;
                response.Message = "Dados salvos no banco";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<ResponseModel<WorkshopModel>> GetOneWorkshop(int id)
        {
            ResponseModel<WorkshopModel> response = new ResponseModel<WorkshopModel>();
            try
            {
                WorkshopModel workshop =  _dataContext.DbWorkshop.FirstOrDefault(x => x.Id == id);

                if( workshop == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Workshop não existente";

                    return response;
                }
                response.Message = "Dado retornada";
                response.Data = workshop;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<ResponseModel<WorkshopModel>> PutWorkshop(WorkshopModel updateWorkshop)
        {
            ResponseModel<WorkshopModel> response = new ResponseModel<WorkshopModel>();
            try
            {
                WorkshopModel workshop =  _dataContext.DbWorkshop.FirstOrDefault(x => x.Id == updateWorkshop.Id);

                if ( workshop == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Workshop não existente";

                    return response;
                }
                workshop.Id = updateWorkshop.Id;
                workshop.Name = updateWorkshop.Name;
                workshop.Description = updateWorkshop.Description;
                workshop.RealizationDate = updateWorkshop.RealizationDate;

                await _dataContext.SaveChangesAsync();

                response.Data = updateWorkshop;
                response.Message = "Dado modificado";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<ResponseModel<WorkshopModel>> DeleteWorkshop(int id)
        {
            ResponseModel<WorkshopModel> response = new ResponseModel<WorkshopModel>();
            try
            {
                WorkshopModel workshop = _dataContext.DbWorkshop.FirstOrDefault(x => x.Id == id);

                if ( workshop == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Workshop não existente";

                    return response;
                }

                _dataContext.DbWorkshop.Remove(workshop);
                await _dataContext.SaveChangesAsync();

                response.Message = "Dado deletado";
                response.Data = workshop;
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
