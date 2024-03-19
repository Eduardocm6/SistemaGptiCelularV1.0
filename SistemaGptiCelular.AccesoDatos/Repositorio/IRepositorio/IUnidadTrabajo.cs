using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGptiCelular.AccesoDatos.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        IPlanRepositorio Plan { get; }
        IVendedorRepositorio Vendedor { get; }
        IMarcaRepositorio Marca {  get; }

        Task Guardar();
    }
}
