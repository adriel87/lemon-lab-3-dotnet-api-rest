using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {

        private readonly IParticipantRepository _participantRepository;

        public ParticipantController(IParticipantRepository eventRepository)
        {
            _participantRepository = eventRepository;
        }

        [HttpGet("participantes")]
        public ActionResult<List<Participant>> GetParticipants()
        {
            return _participantRepository.GetParticipants();
        }


        [HttpGet("participantes/{id}")]
        public ActionResult<Participant> GetParticipantById(int id)
        {
            return _participantRepository.GetParticipantById(id);
        }

        [HttpPost("participantes")]
        public IActionResult AddParticipant([FromBody]Participant participant)
        {
            try
            {
                _participantRepository.AddParticipant(participant);
            }
            catch (Exception e)
            {
                return BadRequest(new {
                    succes = false,
                    Data = e,
                    Key = "Bad Request",
                    Message = e.Message
                });
                
            }
           
            return Created();
        }

        [HttpPut("participantes/{id}")]
        public IActionResult UpdateEvent([FromBody] Participant participant, int id)
        {
            try
            {
                _participantRepository.UpdateParticipant(participant);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    succes = false,
                    Data = e,
                    Key = "Bad Request",
                    Message = e.Message
                });

            }

            return Ok();
        }

        [HttpDelete("participantes/{id}")]
        public IActionResult DeleteParticipant(int id)
        {
            try
            {
                _participantRepository.DeleteParticipant(id);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    succes = false,
                    Data = e,
                    Key = "Bad Request",
                    Message = e.Message
                });

            }

            return Ok();
        }

    }
}
