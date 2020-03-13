using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdministarRenta.Models
{
    public class Alquilado
    {
        [Key,Column(Order =0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public DateTime FechaEntrada { get; set; }

        public Huesped Huésped { get; set; }

        public int HuespedId { get; set; }

        public Casa casa { get; set; }
        public int CasaId { get; set; }

        [Required]
        public int ReservacionDias { get; set; }

        public int Valores { get; set; }

        List<ServicioPrestado> servicioPrestados = new List<ServicioPrestado>();

    }
}
