using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotasApp.Domain.Entities;

namespace NotasApp.Site.Models
{
    public class TodoItemModel
    {
        public int ToDoItemID { get; set; }
        public string Descripcion { get; set; }
        public Prioridad Prioridad { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}