using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using TaskManager.Models;

namespace TaskManager.Controllers
{

    public class TareaController: ApiController
    {

        private  TaskManagerContext _taskManagerContext = new TaskManagerContext();
        private UnitOfWork _unitOfWork;

        public TareaController()
        {
            _unitOfWork = new UnitOfWork(_taskManagerContext);
        }


        [HttpGet]
        public IEnumerable<Tarea> GetAll()
        {
            return _unitOfWork.TareaRepo.GetAll();
        }

        [HttpGet]

        public Tarea Get(int id)
        {
            return _unitOfWork.TareaRepo.Get(id);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Tarea tarea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                tarea.FechaCreacion = DateTime.Now;
                _unitOfWork.TareaRepo.Add(tarea);
                _unitOfWork.TareaRepo.SaveChanges();

                return Ok(new { status = 200, message ="Tarea agregada exitosamente!" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message.ToString());
            }

            
        }
    

        [HttpPut]
        public IHttpActionResult Put([FromBody] Tarea tarea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _unitOfWork.TareaRepo.Update(tarea);
                _unitOfWork.TareaRepo.SaveChanges();

                return Ok(new { status = 200, message = "Tarea actualizada exitosamente!" });
            }
            catch (Exception ex)
            {

                  return BadRequest(ex.Message.ToString());
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _unitOfWork.TareaRepo.Delete(id);
                _unitOfWork.TareaRepo.SaveChanges();

                return Ok(new { status = 200, message = "Se ha eliminado una tarea" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message.ToString());
            }
        }

       

    }
}