using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdministarRenta.Models
{
    public class Responsable
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
      
        public int ResponsableId { get; set; }
        
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string Direccion { get; set; }

        List<Casa> casas = new List<Casa>();
    }
}
