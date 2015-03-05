using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using NotasApp.Domain.Entities;
using NotasApp.Domain.Repositories;
using NotasApp.Site.Filters;
using NotasApp.Site.Models;

namespace NotasApp.Site.Controllers
{
    [ExceptionAttribute]
    [RoutePrefix("api/Todos")]
    public class TodosController : ApiController
    {
        private readonly ITodoItemsRepository _todoItems;

        public TodosController(ITodoItemsRepository todoitemsRepo)
        {
            _todoItems = todoitemsRepo;
        }
        
        public IHttpActionResult Get()
        {
            var todoes = Mapper.Map<List<ToDoItem>, List<TodoItemModel>>(_todoItems.GetToDoItems().ToList());

            return Ok(todoes);
        }

        public IHttpActionResult Get(int id)
        {
            var todo = _todoItems.GetById(id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ToDoItem, TodoItemModel>(todo));
        }

        public IHttpActionResult Post(TodoItemModel todo)
        {
            var model = Mapper.Map<TodoItemModel, ToDoItem>(todo);
            model.FechaCreacion = DateTime.Now;
            model = _todoItems.Add(model);
            todo = Mapper.Map<ToDoItem, TodoItemModel>(model);

            return Created(Url.Link("DefaultApi", new {controller = "Todos", id = todo.ToDoItemID}), todo);
        }

        public IHttpActionResult Put(int id, TodoItemModel todo)
        {
            todo.ToDoItemID = id;
            todo.FechaCreacion = DateTime.Now;

            var todoModel = _todoItems.GetById(id);

            if (todoModel == null)
            {
                return NotFound();
            }

            Mapper.Map(todo, todoModel);

            todoModel = _todoItems.Update(todoModel);
            todo = Mapper.Map<ToDoItem, TodoItemModel>(todoModel);

            return Ok(todo);
        }

        public IHttpActionResult Delete(int id)
        {
            _todoItems.Delete(id);

            return Ok();
        }
    }
}
