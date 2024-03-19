using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGptiCelular.Modelos
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string MarcaModelo { get; set; }

        [Required]
        [MaxLength(10)]
        public string ClaveSap { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
