using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio.IRepositorio
{
    // IDisposable: permite deshaserse de recursos que ya no este usando el sistema.
    public interface IUnidadTrabajo : IDisposable 
    {
        IBodegaRepositorio Bodega {  get; }

        Task Guardar();
    }
}
