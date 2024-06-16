using WebApplication1.Contracts;
using WebApplication1.Models;

namespace WebApplication1.Respositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AplicationDbContext _context;
        public EventRepository(AplicationDbContext context) { _context = context; }
        public void AddEvent(Event evento)
        {
            _context.Events.Add(evento);
            _context.SaveChanges();
        }

        public void DeleteEvent(int id)
        {
            Event evento = GetEventById(id);

            if (evento != null)
            {
                _context.Events.Remove(evento); 
                _context.SaveChanges();
            }
        }

        public Event GetEventById(int id)
        {
            return _context.Events.Find(id); ;
        }

        public List<Event> GetEvents()
        {
            return _context.Events.ToList();
        }

        public void UpdateEvent(Event evento)
        {
            Event eventToUpdate = GetEventById(evento.Id);

            if (evento != null)
            {
                eventToUpdate.StartDate = evento.StartDate;
                eventToUpdate.EndDate = evento.EndDate;
                eventToUpdate.Description = evento.Description;
                eventToUpdate.Name = evento.Name;
                eventToUpdate.Participants = evento.Participants;
            }
            _context.SaveChanges();
        }
    }
}
