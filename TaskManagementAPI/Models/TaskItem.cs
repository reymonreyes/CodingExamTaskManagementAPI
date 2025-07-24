using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagementAPI.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Status
    {
        private static readonly string[] statuses = new string[] { "TODO", "INPROGRESS", "DONE" };
        public static string[] All
        {
            get
            {
                return statuses;
            }
        }
    }
}