using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class TaskManagerContext: DbContext
    {
        public TaskManagerContext() : base("name=TaskManagerDB")
        {
        }

        public static TaskManagerContext Create()
        {
            return new TaskManagerContext();
        }

        public virtual DbSet<Tarea> Tareas { get; set; }
    }
}