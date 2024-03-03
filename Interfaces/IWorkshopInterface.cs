using FastDesafio.Models;

namespace FastDesafio.Interfaces
{
    public interface IWorkshopInterface
    {
        Task<ResponseModel<List<WorkshopModel>>> GetAllWorkshops();
        Task<ResponseModel<WorkshopModel>> GetOneWorkshop( int id);
        Task<ResponseModel<WorkshopModel>> PostWorkshop( WorkshopModel workshop);
        Task<ResponseModel<WorkshopModel>> PutWorkshop( WorkshopModel workshop );
        Task<ResponseModel<WorkshopModel>> DeleteWorkshop( int id);
    }
}
