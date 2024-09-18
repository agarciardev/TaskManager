using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Repository;

namespace TaskManager.Models
{
    public class UnitOfWork
    {
        private TareaRepository _tareaRepository;
        private TaskManagerContext _taskManagerContext;
        public UnitOfWork(TaskManagerContext context) 
        {
            _taskManagerContext = context;
        }

        public TareaRepository TareaRepo
        {
            get
            {
                if (_tareaRepository == null)
                {
                    return _tareaRepository = new TareaRepository(_taskManagerContext);
                }
                return _tareaRepository;
            }
        }

        public void Save()
        {
            _taskManagerContext.SaveChanges();
        }
    }
}