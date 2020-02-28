using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Memoria.Models
{
    public class Evaluation
    {
        public int EvaluationId { get; set; }
        [Required]
        [Display(Name = "Nombre del Alumno")]
        public string NombreAlumno { get; set; }
        [Required]
        [Display(Name = "Nombre de la Memoria")]
        public string NombreMemoria { get; set; }
        [Required]
        [Display(Name = "Numero de Movimientos")]
        public string Movimientos { get; set; }
        [Required]
        [Display(Name = "Tiempo")]
        public string Tiempo { get; set; }
    }
}