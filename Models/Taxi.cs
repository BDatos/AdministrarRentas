using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdministarRenta.Models
{
    public class Taxi
    {
    
        public int TaxiId { get; set; }
        public Chofer Chofer { get; set; }
    
        public int ChoferId { get; set; }

        public Carro Carro { get; set; }

        public string CarroId { get; set; }

        public int Deudas { get; set; }

        List<Itinerario> Itinerarios = new List<Itinerario>();
    }
}
