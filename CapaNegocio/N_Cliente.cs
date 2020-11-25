using CapaEntidades.Entidades;
using CapaNegocio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_Cliente
    {
        ClienteRepositorio oCliente { get; set; }

        public N_Cliente()
        {
            oCliente = new ClienteRepositorio();
        }
        
        public IEnumerable<Cliente> MostrarClientes(string condicion)
        {
            return oCliente.GetClientes(condicion);
        }

        public int AgregarCliente(Cliente nuevoCliente)
        {
            oCliente.InsertCliente(nuevoCliente);
            MessageBox.Show(ClienteRepositorio.Respuesta);
            return nuevoCliente.Id;
        }
    }
}
