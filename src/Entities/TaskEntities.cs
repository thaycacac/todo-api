using System;
using System.Threading.Tasks;

namespace ToDoAPI.Entities
{
    public class TaskEntities 
    {
        public int Id { get; set; }

        public string title {get; set;}

        public string description {get; set;}

        public int complete {get; set;}

        public static implicit operator Task(TaskEntities v)
        {
            throw new NotImplementedException();
        }
    }
}