using Newtonsoft.Json;
using SistemaConsumoApiRest.Entidad;
using SistemaConsumoApiRest.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SistemaConsumoApiRest.Negocio
{
    public class ProductoNegocio
    {
        private readonly HttpClient client;
        private readonly API api;

        public ProductoNegocio()
        {
            client = new HttpClient();
            api = new API();
        }

        public async Task<List<Producto>> ObtenerTodosLosProductos()
        {
            string url = await client.GetStringAsync(api.ListarProductos);
            List<Producto> listaProductos = JsonConvert.DeserializeObject<List<Producto>>(url);
            return listaProductos;
        }
    }
}
