using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TaskListWebApi.Data.Interfaces;
using TaskListWebApi.Dtos;
using TaskListWebApi.Mapper;
using TaskListWebApi.Models;

namespace TaskListWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly IApiRepository _repo;
        private readonly IMapper _mapper;   
        public TaskListController(IApiRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Add(TaskCreateDto taskDto)
        {
            var taskToCreate = _mapper.Map<TaskList>(taskDto);
            
           _repo.Add(taskToCreate);

            if (await _repo.SaveAll())
                return Created("",taskToCreate);

            return BadRequest();
        }
    }
}
