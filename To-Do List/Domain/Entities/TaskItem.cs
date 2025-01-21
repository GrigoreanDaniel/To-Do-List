using System;
using System.ComponentModel.DataAnnotations;

namespace To_Do_List.Domain.Entities {

    public class TaskItem {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public TaskStatus Status { get; set; } = TaskStatus.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    }

    public enum TaskStatus {
        Pending,
        InProgress,
        Completed
    }
}