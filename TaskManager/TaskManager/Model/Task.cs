using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Model
{
    public class Task
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }   
        
        public string Priority { get; set; }

    }
}
