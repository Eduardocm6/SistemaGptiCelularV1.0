using Microsoft.AspNetCore.Mvc;
using SistemaGptiCelular.AccesoDatos.Repositorio.IRepositorio;
using SistemaGptiCelular.Modelos;
using SistemaGptiCelular.Utilidades;

namespace SistemaGptiCelular.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlanController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        public PlanController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index() 
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Plan plan = new Plan();
            if(id == null) 
            {
                // Crear un Nuevo Plan
                plan.Status = true;
                return View(plan);
            }
            // Actualizamos Plan
            plan = await _unidadTrabajo.Plan.Obtener(id.GetValueOrDefault());
            if(plan == null) 
            {
                return NotFound();
            }
            return View(plan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Plan plan)
        {
            if(ModelState.IsValid) 
            {
                if(plan.Id == 0)
                {
                    await _unidadTrabajo.Plan.Agregar(plan);
                    TempData[DS.Exitosa] = "Plan Creado Exitosamente";
                }
                else
                {
                    _unidadTrabajo.Plan.Actualizar(plan);
                    TempData[DS.Exitosa] = "Plan Actualizado Exitosamente";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Exitosa] = "Error al Grabar el Plan";
            return View(plan);
        }
        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos() 
        {
            var todos = await _unidadTrabajo.Plan.ObtenerTodos();
            return Json(new {data = todos});
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id) 
        {
            var planBD = await _unidadTrabajo.Plan.Obtener(id);
            if (planBD == null)
            {
                return Json(new {success = false, message="Error al Borrar Plan"});
            }
            _unidadTrabajo.Plan.Remover(planBD);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Plan borrado Exitosamente" });
        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Plan.ObtenerTodos();
            if(id==0)
            {
                valor = lista.Any(b=>b.Nombre.ToLower().Trim()== nombre.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim() == nombre.ToLower().Trim() && b.Id !=id);
            }
            if(valor)
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });
        }

        #endregion
    }
}
