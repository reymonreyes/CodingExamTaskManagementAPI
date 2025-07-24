using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagementAPI.Exceptions
{
    public class TaskNotFoundException : Exception
    {
        public override string Message =>  "Task not found";
    }
}