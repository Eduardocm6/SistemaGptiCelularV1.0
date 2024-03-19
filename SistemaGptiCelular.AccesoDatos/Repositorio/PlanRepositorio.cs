using SistemaGptiCelular.AccesoDatos.Data;
using SistemaGptiCelular.AccesoDatos.Repositorio.IRepositorio;
using SistemaGptiCelular.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGptiCelular.AccesoDatos.Repositorio
{
    public class VendedorRepositorio : Repositorio<Vendedor>, IVendedorRepositorio
    {
        private readonly ApplicationDbContext _db;

        public VendedorRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Actualizar(Vendedor vendedor)
        {
           var vendedorBD = _db.Vendedores.FirstOrDefault(b => b.Id == vendedor.Id);
            if (vendedorBD != null) 
            {
                vendedorBD.Nombre = vendedor.Nombre;
                vendedorBD.Nip = vendedor.Nip;
                vendedorBD.Status = vendedor.Status;
                _db.SaveChanges();
            }
        }
    }
}
