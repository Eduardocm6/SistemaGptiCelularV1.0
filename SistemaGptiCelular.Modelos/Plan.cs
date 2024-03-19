using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGptiCelular.Modelos
{
    public class Plan
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage ="La Longitud Maxima es de 50 Caracteres")]
        [Required(ErrorMessage ="El Nombre del Plan es Requerido")]
        public string Nombre { get; set; }

        [Required (ErrorMessage ="Los Megas son Requeridos")]
        [MaxLength(5,ErrorMessage ="La Logitud Maxima es de 5 Caracteres")]
        public string Megas { get; set; }
        
        [Required(ErrorMessage ="La Renta Mensual es Requerida")]
        public double Renta { get; set; }
        
        [Required(ErrorMessage ="La Comision es Requerida")]
        public double Comision { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage ="La Longitud Maxima es de 100 Caracteres")]
        public string Observaciones { get; set; }
        
        [Required(ErrorMessage ="El Status es Requerido")]
        public bool Status { get; set; }
    }
}
