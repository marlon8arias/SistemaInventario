using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio.IRepositorio
{
    // Agregamos <T> para que sea genérico, es decir que pueda recibr de bodega o de otro tipo de objeto.
    public interface IRepositorio<T> where T : class
    {   
        // Utilizando la palabra reservada Task, volvemos la logica de forma asyncrona
       Task<T> Obtener(int id);
       Task <IEnumerable<T>> ObtenerTodos(
            Expression<Func<T, bool>> filtro = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string incluirPropiedades = null,
            bool inTracking = true
            );

        Task<T> ObtenerPrimero(
            Expression<Func<T, bool>> filtro = null,
            string incluirPropiedades = null,
            bool isTracking = true
            );

        Task<T> Agregar(T entidad);

        // No pueden ser asyncronos
        void Remover(T entidad);

        void RemoverRango(IEnumerable<T> entidad);
    }
}
