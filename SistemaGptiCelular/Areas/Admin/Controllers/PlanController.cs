﻿using Microsoft.AspNetCore.Mvc;
using SistemaGptiCelular.AccesoDatos.Repositorio.IRepositorio;
using SistemaGptiCelular.Modelos;
using SistemaGptiCelular.Utilidades;

namespace SistemaGptiCelular.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VendedorController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        public VendedorController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index() 
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Vendedor vendedor = new Vendedor();
            if(id == null) 
            {
                // Crear un Nuevo Vendedor
                vendedor.Status = true;
                return View(vendedor);
            }
            // Actualizamos Vendedor
            vendedor = await _unidadTrabajo.Vendedor.Obtener(id.GetValueOrDefault());
            if(vendedor == null) 
            {
                return NotFound();
            }
            return View(vendedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Vendedor vendedor)
        {
            if(ModelState.IsValid) 
            {
                if(vendedor.Id == 0)
                {
                    await _unidadTrabajo.Vendedor.Agregar(vendedor);
                    TempData[DS.Exitosa] = "Vendedor Creado Exitosamente";
                }
                else
                {
                    _unidadTrabajo.Vendedor.Actualizar(vendedor);
                    TempData[DS.Exitosa] = "Vendedor Actualizado Exitosamente";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Exitosa] = "Error al Grabar el Vendedor";
            return View(vendedor);
        }
        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos() 
        {
            var todos = await _unidadTrabajo.Vendedor.ObtenerTodos();
            return Json(new {data = todos});
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id) 
        {
            var vendedorBD = await _unidadTrabajo.Vendedor.Obtener(id);
            if (vendedorBD == null)
            {
                return Json(new {success = false, message="Error al Borrar Vendedor"});
            }
            _unidadTrabajo.Vendedor.Remover(vendedorBD);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Vendedor borrado Exitosamente" });
        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Vendedor.ObtenerTodos();
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
