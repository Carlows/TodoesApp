using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using NotasApp.Domain.Entities;

namespace NotasApp.Domain.Repositories.Implementations
{
    public class TodoItemsRepository : ITodoItemsRepository
    {
        private readonly ApplicationContext _db;

        public TodoItemsRepository(ApplicationContext context)
        {
            _db = context;
        }

        public IEnumerable<ToDoItem> GetToDoItems()
        {
            return _db.TodoItem;
        }

        public ToDoItem GetById(int? id)
        {
            if (id == null) return null;

            return _db.TodoItem.Find(id);
        }

        public IEnumerable<ToDoItem> GetAllBy(Expression<Func<ToDoItem, bool>> predicate)
        {
            if (predicate == null) return _db.TodoItem.ToList();

            return _db.TodoItem.Where(predicate);
        }

        public ToDoItem Add(ToDoItem registro)
        {
            _db.TodoItem.Add(registro);
            _db.SaveChanges();

            return registro;
        }

        public ToDoItem Update(ToDoItem registro)
        {
            _db.Entry(registro).State = EntityState.Modified;
            _db.SaveChanges();

            return registro;
        }

        public void Delete(int? id)
        {
            var registro = _db.TodoItem.Find(id);
            _db.TodoItem.Remove(registro);
            _db.SaveChanges();
        }
    }
}
