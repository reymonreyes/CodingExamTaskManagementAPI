using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Repositories
{
    public interface ITaskRepository : IRepository<TaskItem>
    {
        IEnumerable<TaskItem> GetByStatus(string status);
    }
}
