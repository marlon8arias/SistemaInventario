﻿using SistemaInventario.AccesoDatos.Data;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public IBodegaRepositorio Bodega { get; private set; }



        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Bodega = new BodegaRepositorio(_db);
        }



       // public IBodegaRepositorio Bodega => throw new NotImplementedException();

        public void Dispose()
        {
           _db.Dispose(); // Libera todo lo que está en memoria que ya no se este utilizando.
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}
