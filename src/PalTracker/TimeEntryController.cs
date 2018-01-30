using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
     [Route("/time-entries")]
    public class TimeEntryController:ControllerBase
    {
      
        private readonly ITimeEntryRepository _repository;

        public TimeEntryController(ITimeEntryRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Create([FromBody] TimeEntry timeentry)
        {
            
         var createdTimeEntry = _repository.Create(timeentry);
         
           return CreatedAtRoute("GetTimeEntry", new {id = createdTimeEntry.Id}, createdTimeEntry);
        }
        
         [HttpGet("{id}", Name = "GetTimeEntry")]
        public IActionResult Read(long id)
        {
         return _repository.Contains(id) ? (IActionResult) Ok(_repository.Find(id)) : NotFound();
        
        }
        
         [HttpGet]
        public IActionResult List()
        {
         return Ok(_repository.List());
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody]TimeEntry timeEntry)
        {
        //     if(_repository.Contains(id)==true){
        //         _repository.Update(id,timeEntry);
        //     }
            
        //   var updatedTimeEntry = _repository.Find(id);
        //  return _repository.Contains(id)?(IActionResult) Ok(_repository.Find(id)) : NotFound();
        return _repository.Contains(id) ? (IActionResult) Ok(_repository.Update(id, timeEntry)) : NotFound();
        } 

        [HttpDelete("{id}")]
        public IActionResult Delete(long id )
        {
             //var deleteTimeEntry = _repository.Find(id);
          if(_repository.Contains(id)){
                _repository.Delete(id);
                return NoContent();
            }

          else{
              return NotFound();
          }
        }
      
    }
}