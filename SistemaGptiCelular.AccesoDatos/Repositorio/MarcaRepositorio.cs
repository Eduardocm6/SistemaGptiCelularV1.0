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
    public class MarcaRepositorio : Repositorio<Marca>, IMarcaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public MarcaRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Actualizar(Marca marca)
        {
           var marcaBD = _db.Marcas.FirstOrDefault(b => b.Id == marca.Id);
            if (marcaBD != null) 
            {
                marcaBD.Nombre = marca.Nombre;
                marcaBD.MarcaModelo = marca.MarcaModelo;
                marcaBD.ClaveSap = marca.ClaveSap;
                marcaBD.Status = marca.Status;
                _db.SaveChanges();
            }
        }
    }
}
