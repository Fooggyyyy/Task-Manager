using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Collections;
using System.Collections.Generic;

namespace Task_Manager.Models
{
    public class User
    {
        public int Id;
        public string? Name;
        public string? Email;
        public string? PasswordHash;
        public List<Task?>? Tasks;

        public User(int Id, string? Name, string? Email, string? PassworHash) 
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.PasswordHash = PassworHash;
            Tasks = new List<Task?>();
        }

        public User(int Id, string? Name, string? Email, string? PassworHash, List<Task?>? Tasks)
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.PasswordHash = PassworHash;
            this.Tasks = Tasks;
        }
    }
}
