using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdministarRenta.Models
{
    public class Chofer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CI { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string Direccion { get; set; }

        List<Taxi> Taxis = new List<Taxi>();

    }
}
