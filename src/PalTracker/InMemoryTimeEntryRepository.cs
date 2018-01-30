using System.Collections.Generic;
using System.Linq;

namespace PalTracker
{
    public class InMemoryTimeEntryRepository : ITimeEntryRepository
    {
      private readonly IDictionary<long, TimeEntry> _timeEntries = new Dictionary<long, TimeEntry>();


        public TimeEntry Create(TimeEntry timeEntry){
          long Id = _timeEntries.Count +1;
          timeEntry.Id = Id;
         _timeEntries.Add(Id,timeEntry);
         return _timeEntries[Id];
        }
        public TimeEntry Find(long id){
          return _timeEntries[id];
        }
        public IEnumerable<TimeEntry> List(){
         return _timeEntries.Values.ToList();
        }
        public TimeEntry Update(long id, TimeEntry timeEntry){
          
          timeEntry.Id = id;
           _timeEntries[id] = timeEntry;
          return _timeEntries[id];
        }
       public  void Delete(long id){
            _timeEntries.Remove(id);
        }
        public bool Contains(long id){
          return _timeEntries.ContainsKey(id);
        }




    }
}