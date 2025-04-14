using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Manager.Models
{
    public class Task_
    {
        public int Id;
        public string? Title;
        public string? Description;
        public DateTime Deadline;
        public bool IsCompleted;
        public int UserId;

        [NotMapped]
        public User? User;

        public Task_(int id, string? title, string? description, DateTime deadline, bool isCompleted, int userId, User? user)
        {
            Id = id;
            Title = title;
            Description = description;
            Deadline = deadline;
            IsCompleted = isCompleted;
            UserId = userId;
            User = user;
        }
    }
}
