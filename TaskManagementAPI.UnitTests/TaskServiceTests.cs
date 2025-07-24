using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementAPI.Exceptions;
using TaskManagementAPI.Models;
using TaskManagementAPI.Repositories;
using TaskManagementAPI.Services;
using Xunit;

namespace TaskManagementAPI.UnitTests
{
    public class TaskServiceTests
    {
        //Creating a task (include validation checks)
        [Fact]
        public void Create_ShouldThrowExceptionIfTaskIsNull()
        {
            var taskRepo = new Mock<ITaskRepository>();
            var service = new TaskService(taskRepo.Object);

            Assert.Throws<ValidationException>(() => service.Create(null));
        }

        [Fact]
        public void Create_ShouldThrowExceptionIfTitleIsEmpty()
        {
            var taskRepo = new Mock<ITaskRepository>();
            var service = new TaskService(taskRepo.Object);
            var task = new DTOs.CreateTaskDto();
            
            Assert.Throws<ValidationException>(() => service.Create(task));
        }

        [Fact]
        public void Create_ShouldThrowExceptionIfStatusIsEmpty()
        {
            var taskRepo = new Mock<ITaskRepository>();
            var service = new TaskService(taskRepo.Object);
            var task = new DTOs.CreateTaskDto { Title = "Some task" };
            
            Assert.Throws<ValidationException>(() => service.Create(task));
        }

        [Fact]
        public void Create_ShouldThrowExceptionIfStatusIsInvalid()
        {
            var taskRepo = new Mock<ITaskRepository>();
            var service = new TaskService(taskRepo.Object);
            var task = new DTOs.CreateTaskDto { Title = "Some task", Status = "OTHER" };
            
            Assert.Throws<ValidationException>(() => service.Create(task));
        }

        //Updating a non-existent task
        [Fact]
        public void Update_ShouldThrowExceptionIfTaskDoesNotExist()
        {
            var taskRepo = new Mock<ITaskRepository>();
            taskRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns<TaskItem>(null);
            var service = new TaskService(taskRepo.Object);
            var task = new DTOs.UpdateTaskDto { Title = "Some task", Description = "Some description", Status = "INPROGRESS" };
            
            Assert.Throws<TaskNotFoundException>(() => service.Update(1, task));
        }

        //Filtering by status
        [Fact]
        public void GetByStatus_ShouldThrowExceptionIfStatusIsInvalid()
        {
            var taskRepo = new Mock<ITaskRepository>();
            var service = new TaskService(taskRepo.Object);

            Assert.Throws<ValidationException>(() => service.GetByStatus("OTHER"));
        }
    }
}
