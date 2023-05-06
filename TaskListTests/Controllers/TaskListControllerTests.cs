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
using System.Linq;
using System.Net;

namespace TaskListTests.Controllers
{
    public class TaskListControllerTests
    {
        [Fact]
        public async Task CreateActionResult_ReturnsBadRequest_GivenInvalidModel()
        {
            // Arrange
            var mockRepo = new Mock<IApiRepository>();
            var mockMapper = new Mock<IMapper>();
            var sut = new TaskListController(mockRepo.Object, mockMapper.Object);

            // Act
            var result = await sut.Add(null);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task CreateActionResult_ReturnsNewlyCreatedTaskList()
        {
            // Arrange
            var taskDto = new TaskCreateDto { Description = "Description",Status = true };
            var taskToCreate = new TaskList { Description = "Description", Status = true };

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<TaskList>(taskDto)).Returns(taskToCreate);

            var mockRepo = new Mock<IApiRepository>();
            mockRepo.Setup(r => r.Add(taskToCreate));
            mockRepo.Setup(r => r.SaveAll()).ReturnsAsync(true);

            var controller = new TaskListController(mockRepo.Object, mockMapper.Object);

            // Act
            var result = await controller.Add(taskDto);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.Equal(taskToCreate, createdResult.Value);
            Assert.IsType<CreatedResult>(createdResult);
        }
    }
}
