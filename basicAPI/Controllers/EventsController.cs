using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace basicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private static List<Event> events = new List<Event> {
            new Event { Id = 1, Title = "event 1", Date = new DateTime() },
            new Event { Id = 2, Title = "event 2", Date = new DateTime() },
            new Event { Id = 3, Title = "event 3", Date = new DateTime() } };
        private static int countId = 4;
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }



        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EventsController>
        [HttpPost]
        public Event Post([FromBody] Event newEvent)
        {
            events.Add(new Event { Id = countId, Date = newEvent.Date, Title = newEvent.Title });
            countId++;
            return events[events.Count - 1];
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public Event Put(int id, [FromBody] Event upDateEvent)
        {
            //Predicate<Event> findId = (Event e) => { return e.Id == id; };
            //int index = events.FindIndex(findId);
            int index = events.FindIndex((Event e) => { return e.Id == id; });
            events[index].Title = upDateEvent.Title;
            events[index].Date = upDateEvent.Date;
            return upDateEvent;
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            int index = events.FindIndex((Event e) => { return e.Id == id; });
            events.RemoveAt(index);
        }
    }
}
