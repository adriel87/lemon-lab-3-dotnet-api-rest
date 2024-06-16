using WebApplication1.Contracts;
using WebApplication1.Models;

namespace WebApplication1.Respositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly AplicationDbContext _context;
        public ParticipantRepository(AplicationDbContext context) {  _context = context; }

        public void AddParticipant(Participant participant)
        {
            _context.Participants.Add(participant);
            _context.SaveChanges();
        }


        public void DeleteParticipant(int id)
        {
            Participant participant = GetParticipantById(id);

            if (participant != null)
            {
                _context.Participants.Remove(participant);
                _context.SaveChanges();
            }
        }


        public Participant GetParticipantById(int id)
        {
           return _context.Participants.Find(id);
        }

        public List<Participant> GetParticipants()
        {
            return _context.Participants.ToList();
        }
       

        public void UpdateParticipant(Participant participant)
        {
            Participant participantToUpdate = GetParticipantById(participant.Id);

            if (participantToUpdate != null)
            {
                participantToUpdate.Email= participant.Email;
                participantToUpdate.Events = participant.Events;
                participantToUpdate.Name = participant.Name;
                participantToUpdate.LastName= participant.LastName;
            }
            _context.SaveChanges();
        }
    }
}
