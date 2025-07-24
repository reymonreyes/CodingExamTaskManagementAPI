using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly string _connectionString;

        public TaskRepository()
        {
            _connectionString = $"Data Source={Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~"), "Data\\taskmanager.db")}";
        }

        public IEnumerable<TaskItem> GetAll()
        {
            IEnumerable<TaskItem> result = new List<TaskItem>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                var sql = "SELECT * FROM Tasks";
                result = connection.Query<TaskItem>(sql);
            }

            return result;
        }

        public TaskItem GetById(int id)
        {
            TaskItem result = null;

            using (var connection = new SQLiteConnection(_connectionString))
            {
                var sql = "SELECT * FROM Tasks WHERE Id = @Id";
                result = connection.QueryFirstOrDefault<TaskItem>(sql, new { Id = id });
            }

            return result;
        }

        public void Create(TaskItem task)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Execute("INSERT INTO Tasks (Title, Description, Status, CreatedAt) VALUES (@Title, @Description, @Status, @CreatedAt)", task);
            }
        }

        public void Update(TaskItem task)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Execute("UPDATE Tasks SET Title = @Title, Description = @Description, Status = @Status WHERE Id = @Id", task);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Execute("DELETE FROM Tasks WHERE Id = @Id", new { Id = id });
            }
        }

        public IEnumerable<TaskItem> GetByStatus(string status)
        {
            IEnumerable<TaskItem> result = new List<TaskItem>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                var sql = "SELECT * FROM Tasks WHERE Status = @Status";
                result = connection.Query<TaskItem>(sql, new { Status = status });
            }

            return result;
        }
    }

}