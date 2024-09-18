using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Runtime.CompilerServices;

namespace TaskManager.Models
{
    public class Tarea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TareaId { get; set; }
        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }
        [StringLength(500)]
        public string Descripcion { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Estado { get; set; }
    }
}