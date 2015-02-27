using NotasApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NotasApp.Domain.Repositories
{
    public interface ITodoItemsRepository
    {
        IEnumerable<ToDoItem> GetToDoItems();
        ToDoItem GetById(int? id);
        IEnumerable<ToDoItem> GetAllBy(Expression<Func<ToDoItem, bool>> predicate);
        ToDoItem Add(ToDoItem registro);
        ToDoItem Update(ToDoItem registro);
        void Delete(int? id);
    }
}
