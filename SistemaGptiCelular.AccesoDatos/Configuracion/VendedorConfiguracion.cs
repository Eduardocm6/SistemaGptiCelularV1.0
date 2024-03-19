using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGptiCelular.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGptiCelular.AccesoDatos.Configuracion
{
    public class PlanConfiguracion : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Megas).IsRequired().HasMaxLength(5);
            builder.Property(x => x.Renta).IsRequired();
            builder.Property(x => x.Comision).IsRequired();
            builder.Property(x => x.Observaciones).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
