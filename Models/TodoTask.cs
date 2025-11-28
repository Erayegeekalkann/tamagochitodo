using System;
using System.Collections.Generic;

namespace TamagotchiTodo.Models
{
    public class TodoTask
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public bool IsCompleted { get; set; }

        // Custom stat impacts when task is completed
        public Dictionary<string, int> StatImpacts { get; set; } = new Dictionary<string, int>();

        public TodoTask()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
    }
}
