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
    [RoutePrefix("api/Todos")]
    public class TodosController : ApiController
    {
        private readonly ITodoItemsRepository _todoItems;

        public TodosController(ITodoItemsRepository todoitemsRepo)
        {
            _todoItems = todoitemsRepo;
        }
        
        [ExceptionAttribute]
        public IEnumerable<TodoItemModel> Get()
        {
            return Mapper.Map<List<ToDoItem>, List<TodoItemModel>>(_todoItems.GetToDoItems().ToList());
        }
    }
}
