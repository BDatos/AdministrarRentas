using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdministarRenta.Models
{
    public class Itinerario
    {


        public Taxi Taxi{ get; set; }


        public Huesped Huesped { get; set; }
       

        public int HuespedId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime FechaRecogida { get; set; }

        [Required]
        public int CantidasDeDias { get; set; }
        
        [Required]
        public string Jefe { get; set; }

        [Required]
        public string Recorrido { get; set; }

        public string Resumen { get; set; }

       
    }
}
