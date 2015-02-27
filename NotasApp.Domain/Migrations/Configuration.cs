using NotasApp.Domain.Entities;

namespace NotasApp.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "NotasApp.Domain.Entities.ApplicationContext";
            AutomaticMigrationDataLossAllowed = true;
        }

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
        }
    }
}
