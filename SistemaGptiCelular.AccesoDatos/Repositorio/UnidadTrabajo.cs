﻿using SistemaGptiCelular.AccesoDatos.Data;
using SistemaGptiCelular.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGptiCelular.AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public IPlanRepositorio Plan {  get; private set; }
        public IVendedorRepositorio Vendedor { get; private set; }
        public IMarcaRepositorio Marca { get; private set; }
        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Plan = new PlanRepositorio(_db);
            Vendedor = new VendedorRepositorio(_db);
            Marca= new MarcaRepositorio(_db);
        }
        public void Dispose()
        {
           _db.Dispose();
        }

        public async Task Guardar()
        {
           await _db.SaveChangesAsync();
        }
    }
}
