using NotasApp.Domain.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasApp.Domain.Entities
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("DefaultConnection")
        {
            // Para activar automatic migrations
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationContext, Configuration>());
            Database.SetInitializer<ApplicationContext>(new DbInitializerNotas());
        }

        public DbSet<ToDoItem> TodoItem { get; set; }
    }

    public class DbInitializerNotas : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            Array array = Enum.GetValues(typeof(Prioridad));
            Random rand = new Random();

            for (int index = 1; index <= 20; index++)
            {
                context.TodoItem.Add(new ToDoItem()
                {
                    Descripcion = String.Format("Sum dummy description numbah {0}", index),
                    Prioridad = (Prioridad)array.GetValue(rand.Next(array.Length))
                });
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
