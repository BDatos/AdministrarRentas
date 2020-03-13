using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AdministarRenta.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdministarRenta.Models
{
    public class Casa
    {   [Key]
        public int CasaId { get; set; }
        public string Descripcion { get; set; }

        [Required]
        public string Ubicacion { get; set; }
        
        [Required]
        public int Cantidad_Cuartos { get; set; }

        [Required]
        public int Cantida_WC { get; set; }
        int Deuda { get; set; }

        public Responsable Responsable { get; set; }

        [ ForeignKey("Responsable")]
        public int ResponsableId { get; set; }



        List<Alquilado> Alquilados = new List<Alquilado>();

    }
}
