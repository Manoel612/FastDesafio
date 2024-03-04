using FastDesafio.Models;

namespace FastDesafio.Interfaces
{
    public interface IRecordInterface
    {
        Task<ResponseModel<List<RecordModel>>> GetAllRecords();
        Task<ResponseModel<RecordModel>> GetOneRecord(int id);
        //Task<ResponseModel<RecordModel>> PostRecord(int workshopId);
        Task<ResponseModel<RecordModel>> PutRecord(RecordModel record);
        Task<ResponseModel<RecordModel>> DeleteRecord(int id);
        Task<ResponseModel<CollaboratorModel>> AddCollaborator(int collaboratorId, int recordId);
        Task<ResponseModel<CollaboratorModel>> RemoveCollaborator(int collaboratorId, int recordId);
        Task<ResponseModel<List<CollaboratorModel>>> GetAllCollaboratorsInWorkshop( int workshopId);

    }
}
