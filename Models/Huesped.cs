using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AdministarRenta.Models
{
    public class Huesped
    {
        [Key]
        
        public int HuespedId { get; set; }
        [Required]
        public string Nombre { get; set; }

        public string NombreAereolin { get; set; }

        public DateTime HoraDeLlegada { get; set; }

        public int CantAcompañantes { get; set; }

        List<Alquilado> Alquilados = new List<Alquilado>();

        List<Itinerario> Itinerarios = new List<Itinerario>();
    }
}
