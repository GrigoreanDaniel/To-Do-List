using System;
using System.ComponentModel.DataAnnotations;

namespace To_Do_List.Domain.Entities {

    public class TaskItem {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500)]
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