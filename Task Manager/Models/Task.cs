using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Collections;
using System.Collections.Generic;

namespace Task_Manager.Models
{
    public class Task
    {
        public int Id;
        public string? Title;
        public string? Description;
        public DateTime Deadline;
        public bool IsCompleted;
        public int UserId;
        public User? User;


    }
}
