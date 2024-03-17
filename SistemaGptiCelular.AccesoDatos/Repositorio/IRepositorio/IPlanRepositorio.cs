using SistemaGptiCelular.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGptiCelular.AccesoDatos.Repositorio.IRepositorio
{
    public interface IPlanRepositorio : IRepositorio<Plan>
    {
        void Actualizar(Plan plan);
    }
}
