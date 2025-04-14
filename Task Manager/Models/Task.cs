using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Manager.Models
{
    public class TaskInManage
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        [Required] 
        [StringLength(100)] 
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        public bool IsCompleted { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")] 
        public User User { get; set; }

        public TaskInManage() { }

        public TaskInManage(string title, string description, DateTime deadline, int userId)
        {
            Title = title;
            Description = description;
            Deadline = deadline;
            UserId = userId;
            IsCompleted = false;
        }
    }
}