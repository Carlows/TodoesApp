using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasApp.Domain.Entities
{
    public class ToDoItem
    {
        public ToDoItem()
        {
            FechaCreacion = DateTime.Now;
        }

        public int ToDoItemID { get; set; }
        public string Descripcion { get; set; }
        public Prioridad Prioridad { get; set; }
        public DateTime FechaCreacion { get; set; }

    }

    public enum Prioridad
    {
        Alta,
        Media,
        Baja,
        Indefinida
    }
}
