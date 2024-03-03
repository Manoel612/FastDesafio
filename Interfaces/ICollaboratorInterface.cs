using FastDesafio.Models;

namespace FastDesafio.Interfaces
{
    public interface ICollaboratorInterface
    {
        Task<ResponseModel<List<CollaboratorModel>>> GetAllCollaborators();
        Task<ResponseModel<CollaboratorModel>> GetOneCollaborator(int id);
        Task<ResponseModel<CollaboratorModel>> PostCollaborator(CollaboratorModel collaborator);
        Task<ResponseModel<CollaboratorModel>> PutCollaborator(CollaboratorModel updateCollaborator);
        Task<ResponseModel<CollaboratorModel>> DeleteCollaborator(int id);
    }
}
