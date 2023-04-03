using AutoMapper;
using Moq;
using System;
using System.Threading.Tasks;
using TaskListWebApi.Controllers;
using TaskListWebApi.Data.Interfaces;
using TaskListWebApi.Dtos;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using TaskListWebApi.Models;
using System.Collections.Generic;
using TaskListTests.Fixtures;
using System.Linq;
using System.Net;

namespace TaskListTests.Controllers
{
    public class TaskListControllerTests
    {
        [Fact]
        public async Task Get_OnSuccess_InvokesTask()
        {
            //Arrange
            var mockTaskRepo = new Mock<IApiRepository>();
            var mockTaskMap = new Mock<IMapper>();

            mockTaskRepo
                .Setup(service => service
                .GetTaskListsAsync())
                .ReturnsAsync(TaskFixtures.GetTasklists());
            var sut = new TaskListController(mockTaskRepo.Object, mockTaskMap.Object);

            //Act
            var result = (OkObjectResult)await sut.Get();

            //Assert
            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task Get_OnSuccess_InvokesTaskServiceExactilyOnce()
        {
            //Arrange
            var mockTaskRepo = new Mock<IApiRepository>();
            var mockTaskMap = new Mock<IMapper>();

            mockTaskRepo
                .Setup(service => service
                .GetTaskListsAsync())
                .ReturnsAsync(TaskFixtures.GetTasklists());
            var sut = new TaskListController(mockTaskRepo.Object, mockTaskMap.Object);

            //Act
            var result = await sut.Get();

            //Assert
            mockTaskRepo.Verify(service => service.GetTaskListsAsync(), Times.Once());
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnListOfTasks()
        {
            //Arrange
            var mockTaskRepo = new Mock<IApiRepository>();
            var mockTaskMap = new Mock<IMapper>();

            mockTaskRepo
                .Setup(service => service
                .GetTaskListsAsync())
                .ReturnsAsync(TaskFixtures.GetTasklists());

            var sut = new TaskListController(mockTaskRepo.Object, mockTaskMap.Object);

            //Act
            var result = await sut.Get();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            var objetResult  = (OkObjectResult)result;
            objetResult.Value.Should().BeOfType<List<TaskList>>();
        }

        [Fact]
        public async Task Get_GetOnNoTaskFound_Return404()
        {
            //Arrange
            var mockTaskRepo = new Mock<IApiRepository>();
            var mockTaskMap = new Mock<IMapper>();

            mockTaskRepo
                .Setup(service => service
                .GetTaskListsAsync()).ReturnsAsync(new List<TaskList>());
            var sut = new TaskListController(mockTaskRepo.Object, mockTaskMap.Object);

            //Act
            var result = await sut.Get();

            //Assert
            result.Should().BeOfType<NotFoundResult>();
            var objetResult = (NotFoundResult)result;
            objetResult.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnListATaskById()
        {
            //Arrange
            var mockTaskRepo = new Mock<IApiRepository>();
            var mockTaskMap = new Mock<IMapper>();

            mockTaskRepo
                .Setup(service => service.GetTaskListsAsync())
                .ReturnsAsync(TaskFixtures.GetTasklists());

            var sut = new TaskListController(mockTaskRepo.Object, mockTaskMap.Object);

            //Act
            var result = await sut.Get();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            var objetResult = (OkObjectResult)result;
            objetResult.Value.Should().BeOfType<List<TaskList>>();
        }

        [Fact]
        public async Task Index_Returns_View_Result_WithTaskModel()
        {
            // Arrange
            int taskId = 1;
            var mockRepo = new Mock<IApiRepository>();
            var mockTaskMap = new Mock<IMapper>();
            mockRepo.Setup(repo => repo.GetTaskListById(taskId))
                .ReturnsAsync(TaskFixtures.GetTasklists().FirstOrDefault(
                    s => s.Id == taskId));
            var sut = new TaskListController(mockRepo.Object, mockTaskMap.Object);

            // Act
            var result = await sut.Get(taskId);

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task ForTask_Returns_HttpNotFound_ForInvalidTask()
        {
            // Arrange
            int taskId = 3;
            var mockRepo = new Mock<IApiRepository>();
            var mockTaskMap = new Mock<IMapper>();
            mockRepo.Setup(repo => repo.GetTaskListById(taskId))
                .ReturnsAsync((TaskList)null);
            var sut = new TaskListController(mockRepo.Object, mockTaskMap.Object);

            // Act
            var result = await sut.Get(taskId);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task CreateActionResult_ReturnsBadRequest_GivenInvalidModel()
        {
            // Arrange
            var mockRepo = new Mock<IApiRepository>();
            var mockTaskMap = new Mock<IMapper>();
            var sut = new TaskListController(mockRepo.Object, mockTaskMap.Object);

            // Act
            var result = await sut.Add(null);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task CreateActionResult_ReturnsNewlyCreatedTaskList()
        {
            // Arrange
            int taskId = 3;
            string taskDescription = "Task description";
            bool taskStatus = true;
            var mockRepo = new Mock<IApiRepository>();
            var mockTaskMap = new Mock<IMapper>();

            var task = TaskFixtures.GetTasklists().FirstOrDefault(s => s.Id == taskId);

            mockRepo.Setup(repo => repo.GetTaskListById(taskId))
                .ReturnsAsync(task);

           

            var sut = new TaskListController(mockRepo.Object,mockTaskMap.Object);

            var newTask = new TaskCreateDto()
            {
               Description = taskDescription,
               Status = taskStatus
            };
            
            // Act
            var result = await sut.Add(newTask);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);

        }

        

    }
}
