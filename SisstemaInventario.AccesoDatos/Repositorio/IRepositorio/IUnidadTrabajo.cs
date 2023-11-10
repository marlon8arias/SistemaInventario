using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisstemaInventario.AccesoDatos.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable // IDisposable permite deshacerte de cualquier recurso que hayas obtenido del sistema, se quitan objeetos que no se estan usando
    {
        IBodegaRepositorio Bodega {  get; }
        Task Guardar();
    }
}
