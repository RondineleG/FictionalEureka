using FictionalEureka.API.Entities;
using FictionalEureka.API.Repository;
using FictionalEureka.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FictionalEureka.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDoController : ControllerBase
{
    private readonly ToDoRepository taskRepo;

    public ToDoController()
    {
        taskRepo = new ToDoRepository();
    }

    /// <summary>
    /// Get all Todos
    /// </summary>
    /// <returns>A list of todos</returns>
    [HttpGet]
    public IActionResult GetTaskToDo()
    {
        var taskList = taskRepo.Listar();
        return Ok(taskList);
    }

    /// <summary>
    /// Get a Todo by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>A only todo</returns>
    [HttpGet("{id}")]
    public IActionResult GetTaskToDo(Guid id)
    {
        var taskToDo = taskRepo.Consultar(id);

        if (taskToDo == null)
        {
            return NotFound();
        }

        return Ok(taskToDo);
    }

   /// <summary>
   /// Update todo
   /// </summary>
   /// <param name="id"></param>
   /// <param name="toDo"></param>
   /// <returns>Updated todo</returns>
    [HttpPut("{id}")]
    public IActionResult PutTaskToDo(Guid id, [FromBody] ToDo toDo)
    {
        var response = taskRepo.Alterar(toDo, id);
        if (!response)
            return BadRequest();

        return Ok();
    }

    /// <summary>
    /// Add a new todo
    /// </summary>
    /// <param name="toDo"></param>
    /// <returns>new todo</returns>
    [HttpPost]
    public IActionResult PostTaskToDo(ToDoViewModel toDo)
    {
        var taskModel = new ToDo() { Active = true, Nome = toDo.Nome };
        taskRepo.Adicionar(taskModel);
        return Ok(taskModel);
    }

    /// <summary>
    /// Delete tod by id
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public void DeleteTaskToDo(Guid id)
    {
        taskRepo.Excluir(id);
    }
}
