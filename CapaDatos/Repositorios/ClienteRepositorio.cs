using CapaEntidades.Entidades;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CapaNegocio.Repositorios
{
    public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
    {
        private readonly NCapasContexto _contexto;
        private readonly IDbConnection _conexion;
        public static string Respuesta { get; private set; }

        public ClienteRepositorio()
        {
            // Contexto "EntityFramework"
            _contexto = new NCapasContexto();
            // Conexión "Dapper"
            _conexion = new SqlConnection(
                ConfigurationManager.ConnectionStrings["NCapasContext"].ConnectionString);
        }

        /// <summary>
        /// Obtiene todos los Clientes de la base de datos utilizando el procedimiento
        /// almacenado spCLIENTES_Buscar.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns></returns>
        public IEnumerable<Cliente> GetClientes(string condicion)
        {
            using (_contexto)
            {
                return _contexto.Cliente.SqlQuery("spCLIENTES_Buscar @condicion",
                                                  new SqlParameter("condicion", condicion)
                                                  ).ToList();
            }
        }

        /// <summary>
        /// Agrega un nuevo cliente a la base de datos utilizando el procedimiento
        /// almacenado spCLIENTES_Insertar.
        /// </summary>
        /// <param name="cliente">Objeto Cliente con sus respectivos datos.</param>
        /// <returns>Un objeto Cliente.</returns>
        public Cliente InsertCliente(Cliente cliente)
        {
            // Utilizando Dapper
            using (_conexion)
            {
                var p = new DynamicParameters();

                // Parámetros
                p.Add("@nombre", cliente.Nombre);
                p.Add("@apellido", cliente.Apellido);
                p.Add("@dni", cliente.Dni);
                p.Add("@direccion", cliente.Direccion);
                p.Add("@ciudad", cliente.Ciudad);
                p.Add("@telefono", cliente.Telefono);
                p.Add("@email", cliente.Email);
                // Parámetro de salida (Indica si el cliente fue registrado)
                p.Add("@mensaje", dbType: DbType.String, size: 100, direction: ParameterDirection.Output);

                // Ejecutar procedimiento almacenado
                _conexion.Execute(
                    "dbo.spCLIENTES_Insertar",
                    p,
                    commandType: CommandType.StoredProcedure);

                Respuesta = p.Get<string>("@mensaje");

                return cliente;
            }
        }
    }
}
