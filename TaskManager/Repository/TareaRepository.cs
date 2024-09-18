using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Models;

namespace TaskManager.Repository
{
    public class TareaRepository
    {
        private readonly TaskManagerContext _context;

        public TareaRepository(TaskManagerContext context)
        {
            _context = context;
        }

        public void Add(Tarea tarea)
        {
            _context.Tareas.Add(tarea);
        }
        public void Update(Tarea tarea) { 
            //_context.Tareas.Attach(tarea);
            _context.Entry(tarea).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Tarea tarea)
        {
            _context.Tareas.Remove(tarea);
        }

        public Tarea Get(int id) 
        { 
            return _context.Tareas.Find(id);
        }
        public IEnumerable<Tarea> GetAll()
        {
            return _context.Tareas.ToList();
        }

        public void Delete(int id)
        {
            _context.Tareas.Remove(_context.Tareas.Find(id));
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}