using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagementAPI.DTOs;
using TaskManagementAPI.Exceptions;
using TaskManagementAPI.Models;
using TaskManagementAPI.Repositories;

namespace TaskManagementAPI.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _repo;

        public TaskService(ITaskRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<TaskDto> GetAll()
        {
            return _repo.GetAll().Select(MapToDto);
        }

        public TaskDto GetById(int id)
        {
            var task = _repo.GetById(id);
            if (task == null)
                return null;

            return MapToDto(task);
        }

        public void Create(CreateTaskDto dto)
        {
            if (dto is null) throw new ValidationException("Task is required");
            if (string.IsNullOrWhiteSpace(dto.Title)) throw new ValidationException("Title is required");
            if (string.IsNullOrWhiteSpace(dto.Status)) throw new ValidationException("Status is required");
            if (!Status.All.Contains(dto.Status)) throw new ValidationException($"Status {dto.Status} is invalid");
            
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                Status = dto.Status,
                CreatedAt = DateTime.UtcNow
            };

            _repo.Create(task);
        }

        public void Update(int id, UpdateTaskDto dto)
        {
            if (dto is null) throw new ValidationException("Task is required");
            if (string.IsNullOrWhiteSpace(dto.Title)) throw new ValidationException("Title is required");
            if (string.IsNullOrWhiteSpace(dto.Status)) throw new ValidationException("Status is required");
            if (!Status.All.Contains(dto.Status)) throw new ValidationException($"Status {dto.Status} is invalid");

            var existing = _repo.GetById(id);
            if (existing == null) throw new TaskNotFoundException();

            existing.Title = dto.Title;
            existing.Description = dto.Description;
            existing.Status = dto.Status;
            _repo.Update(existing);
        }

        public void Delete(int id)
        {
            var existing = _repo.GetById(id);
            if (existing == null) throw new TaskNotFoundException();

            _repo.Delete(id);
        }

        public IEnumerable<TaskDto> GetByStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status) || !Status.All.Contains(status)) throw new ValidationException($"Status {status ?? "empty"} is invalid");
            
            return _repo.GetByStatus(status).Select(MapToDto);
        }

        private TaskDto MapToDto(TaskItem task) 
        {
            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                CreatedAt = task.CreatedAt
            };
        }
    }

}