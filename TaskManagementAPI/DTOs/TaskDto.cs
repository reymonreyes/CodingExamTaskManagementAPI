﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagementAPI.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}