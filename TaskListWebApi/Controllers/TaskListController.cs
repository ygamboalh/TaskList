using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TaskListWebApi.Data.Interfaces;
using TaskListWebApi.Dtos;
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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasklist = await _repo.GetTaskListsAsync();
            if (tasklist.Any())
                return Ok(tasklist);
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var task = await _repo.GetTaskListById(id);

            if (task == null)
                return NotFound("Task not found");

            var taskDto = _mapper.Map<TaskList>(task);

            return Ok(taskDto);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Add(TaskCreateDto taskDto)
        {
            var taskToCreate = _mapper.Map<TaskList>(taskDto);
            
           _repo.Add(taskToCreate);

            if (await _repo.SaveAll())
                return Ok(taskToCreate);

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TaskUpdateDto taskDto)
        {
            if (id != taskDto.Id)
                return BadRequest("Ids do not match");

            var taskToUpdate = await _repo.GetTaskListById(taskDto.Id);

            if (taskToUpdate == null)
                return BadRequest();

            _mapper.Map(taskDto, taskToUpdate);

            if (!await _repo.SaveAll())
                return NoContent();
            return Ok(taskToUpdate);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _repo.GetTaskListById(id);
            if (task == null)
                return NotFound("Task not found");
            _repo.Delete(task);
            if (!await _repo.SaveAll())
                return BadRequest("Could not delete task");
            return Ok("Task deleted");

        }
    }
}
