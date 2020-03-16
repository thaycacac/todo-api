using System;

namespace DapperSeries.Entities
{
    public class TaskDTO 
    {
        public int Id { get; set; }

        public string title {get; set;}

        public string description {get; set;}

        public int user {get; set;}
    }
}