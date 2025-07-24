using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagementAPI.DTOs;
using TaskManagementAPI.Exceptions;
using TaskManagementAPI.Models;
using TaskManagementAPI.Services;

namespace TaskManagementAPI.Controllers
{
    [RoutePrefix("api/tasks")]
    public class TasksController : ApiController
    {
        private readonly TaskService _service;

        public TasksController(TaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<TaskDto> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet]
        [Route("{id:int}")]         
        public TaskDto GetById(int id) 
        {
            return _service.GetById(id);
        }

        [HttpPost]
        [ValidationExceptionFilter]
        public void Create(CreateTaskDto dto)
        {
            _service.Create(dto);
        }

        [HttpPut]
        [Route("{id:int}")]
        [TaskNotFoundExceptionFilter]
        [ValidationExceptionFilter]
        public void Update(int id, UpdateTaskDto dto)
        {
            _service.Update(id, dto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [TaskNotFoundExceptionFilter]
        public void Delete(int id)
        {
            _service.Delete(id);
        }

        [HttpGet]
        [Route("status/{status}")]
        [ValidationExceptionFilter]
        public IEnumerable<TaskDto> GetByStatus(string status)
        {
            return _service.GetByStatus(status);
        }
    }    
}
