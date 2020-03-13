using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdministarRenta.Models
{
    public class Carro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Matricula { get; set; }

        [Required]
        public string Marca { get; set; }
        public string Modelo { get; set; }
     
        [Required]
        public int capacidad { get; set; }

        List<Taxi> Taxis = new List<Taxi>();
    }
}
