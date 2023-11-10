using Microsoft.EntityFrameworkCore;
using SisstemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.AccesoDatos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SisstemaInventario.AccesoDatos.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }


        public async Task Agregar(T entidad)
        {
            await dbSet.AddAsync(entidad); // equivalencia a un INSERT INTO TABLE
        }

        public async Task<T> Obtener(int id)
        {
            return await dbSet.FindAsync(id); // SELECT * FROM (TRABAJA SOLAMENTE CON EL ID)
        }

        public async Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string incluirPropiedades = null, bool isTrackin = true)
        {
            IQueryable<T> query = dbSet;
            if(filtro != null)
            {
                query = query.Where(filtro); // SELECT * FROM WHERE = ?
            }

            if(incluirPropiedades != null)
            {
                // Cada vez que encuentre una coma, separarlo. Y remover espacios vacios
                foreach (var incluirProp in incluirPropiedades.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp); // Incluir los elementos relacionales. Ej: Catagoria, Marca
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (!isTrackin)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task<T> ObtenerPrimero(Expression<Func<T, bool>> filtro = null, string incluirPropiedades = null, bool isTrackin = true)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro); // SELECT * FROM WHERE = ?
            }

            if (incluirPropiedades != null)
            {
                // Cada vez que encuentre una coma, separarlo. Y remover espacios vacios
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp); // Incluir los elementos relacionales. Ej: Catagoria, Marca
                }
            }

            if (!isTrackin)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync();
        }

       

        public void Remover(T entidad)
        {
            dbSet.Remove(entidad); // DELETE EN LA BASE DE DATOS
        }

        public void RemoveRango(IEnumerable<T> entidad)
        {
            dbSet.RemoveRange(entidad);
        }
    }
}
