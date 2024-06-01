using System;

namespace TodoListAPI.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public bool IsDone { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
