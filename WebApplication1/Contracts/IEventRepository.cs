using WebApplication1.Models;

namespace WebApplication1.Contracts
{
    public interface IEventRepository
    {
        List<Event> GetEvents();
        Event GetEventById(int id);
        void AddEvent(Event evento);
        void UpdateEvent(Event evento);
        void DeleteEvent(int id);
    }
}
