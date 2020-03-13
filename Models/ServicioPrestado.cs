using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdministarRenta.Models
{
    public class ServicioPrestado
    {
        [Key]
        public int ServiciosPrestadoId { get; set; }

        public Huesped Huésped { get; set; }

        public int HuespedId { get; set; }

        public Servicios Servicios { get; set; }

        public int ServiciosId { get; set; }

        public string Resumen { get; set; }


    }
}
