using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api")]
    [ApiController]
    public class EventsController : ControllerBase
    {

        private readonly IEventRepository _eventRepository;

        public EventsController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet("eventos")]
        public ActionResult<List<Event>> GetEvents()
        {
            return _eventRepository.GetEvents();
        }


        [HttpGet("eventos/{id}")]
        public ActionResult<Event> GetEventById(int id)
        {
            return _eventRepository.GetEventById(id);
        }

        [HttpPost("eventos")]
        public ActionResult<bool> AddEvent([FromBody]Event evento)
        {
            try
            {
                _eventRepository.AddEvent(evento);
            }
            catch (Exception)
            {
                return false;
                
            }
           
            return true;
        }

        [HttpPut("eventos/{id}")]
        public ActionResult<bool> UpdateEvent([FromBody] Event @event)
        {
            try
            {
                _eventRepository.UpdateEvent(@event);
            }
            catch (Exception)
            {
                return false;

            }

            return true;
        }

        [HttpDelete("eventos/{id}")]
        public ActionResult<bool> DeleteEvent(int id)
        {
            try
            {
                _eventRepository.DeleteEvent(id);
            }
            catch (Exception)
            {
                return false;

            }

            return true;
        }

    }
}
