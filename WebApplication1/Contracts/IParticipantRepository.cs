using WebApplication1.Models;

namespace WebApplication1.Contracts
{
    public interface IParticipantRepository
    {
        List<Participant> GetParticipants();
        Participant GetParticipantById(int id);
        void AddParticipant(Participant participant);
        void UpdateParticipant(Participant participant);
        void DeleteParticipant(int id);
    }
}
