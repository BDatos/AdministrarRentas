using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdministarRenta.Models
{
    public class Servicios
    {
        [Key]
        public int ServicioID { get; set; }

        [Required]
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        
        [Required]
        public int Cantidad { get; set; }

        List<ServicioPrestado> servicioPrestados = new List<ServicioPrestado>();
    }
}
