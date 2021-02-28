using System;

namespace TodoList.Dtos
{
    public class TodoItemReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DT_DeadLine { get; set; }
        public DateTime? DT_Done { get; set; }
        public int Priority { get; set; }
    }
}