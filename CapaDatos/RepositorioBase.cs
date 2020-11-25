using CapaEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace CapaNegocio
{
    public class RepositorioBase<TEntidad> where TEntidad : class
    {
        protected NCapasContexto contexto = new NCapasContexto();
        protected IDbConnection conexion = new SqlConnection(
                ConfigurationManager.ConnectionStrings["NCapasContext"].ConnectionString);
        protected DbSet<TEntidad> tabla;

        public RepositorioBase()
        {
            tabla = contexto.Set<TEntidad>();
        }

        /// <summary>
        /// Obtiene la primera entidad o la entidad por defecto según la condición, el orden y las
        /// claves foráneas indicadas.
        /// </summary>
        /// <param name="filter">Condición de búsqueda.</param>
        /// <param name="orderBy">Orden en el cual se proyectarán los elementos.</param>
        /// <param name="includeProperties">Claves foráneas a incluir en la proyección.</param>
        /// <returns>Un <see cref="IEnumerable{TEntity}"/> que contiene los elementos que satisfacen
        /// la condición especificada por <paramref name="filter"/>.</returns>
        public virtual IEnumerable<TEntidad> Get(
            Expression<Func<TEntidad, bool>> filter = null,
            Func<IQueryable<TEntidad>, IOrderedQueryable<TEntidad>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntidad> query = tabla;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        /// Obtiene la entidad que coincide con el Id ingresado.
        /// </summary>
        /// <param name="id">Clave primaria de la entidad.</param>
        /// <returns>La entidad que coincide con el <paramref name="id"/> ingresado.</returns>
        public virtual TEntidad GetById(object id)
        {
            return tabla.Find(id);
        }

        /// <summary>
        /// Inserta un nuevo registro en la base de datos de la tabla correspondiente.
        /// </summary>
        /// <param name="registro">Registro a insertar.</param>
        public virtual void Insert(TEntidad registro)
        {
            tabla.Add(registro);
        }

        public virtual void Update(TEntidad registro)
        {
            tabla.Attach(registro);
            contexto.Entry(registro).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            TEntidad registro = tabla.Find(id);
            Delete(registro);
        }
    }
}
