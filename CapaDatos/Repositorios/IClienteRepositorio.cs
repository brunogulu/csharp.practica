using CapaEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Repositorios
{
    public interface IClienteRepositorio
    {
        IEnumerable<Cliente> GetClientes(string condicion);
    }
}
