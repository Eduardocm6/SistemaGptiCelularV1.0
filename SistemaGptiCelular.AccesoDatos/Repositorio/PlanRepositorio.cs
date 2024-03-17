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
    public class PlanRepositorio : Repositorio<Plan>, IPlanRepositorio
    {
        private readonly ApplicationDbContext _db;

        public PlanRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Actualizar(Plan plan)
        {
           var planBD = _db.Planes.FirstOrDefault(b => b.Id == plan.Id);
            if (planBD != null) 
            {
                planBD.Nombre = plan.Nombre;
                planBD.Megas = plan.Megas;
                planBD.Renta = plan.Renta;
                planBD.Comision = plan.Comision;
                planBD.Observaciones = plan.Observaciones;
                planBD.Status = plan.Status;
                _db.SaveChanges();
            }
        }
    }
}
