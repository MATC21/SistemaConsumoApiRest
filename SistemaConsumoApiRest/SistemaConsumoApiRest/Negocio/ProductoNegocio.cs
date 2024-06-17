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
            try
            {
                string url = await client.GetStringAsync(api.ListarProductos);
                List<Producto> listaProductos = JsonConvert.DeserializeObject<List<Producto>>(url);
                return listaProductos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mostrar los productos: {ex.Message}");
                return null;
            }

        }

        public async Task<Producto> CrearProducto(Producto modelo)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(modelo);

                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Enviar la solicitud POST
                var response = await client.PostAsync(api.CrearProducto, content);

                // Verificar si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta y deserializarla en un objeto Producto
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var productoCreado = JsonConvert.DeserializeObject<Producto>(responseContent);
                    return productoCreado;
                }
                else
                {
                    // Manejar el caso en que la solicitud no fue exitosa
                    throw new Exception($"Error al crear el producto: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el producto: {ex.Message}");
                return null;
            }

        }

        public async Task<bool> EliminarProducto(int id)
        {
            try
            {
                var responce = await client.DeleteAsync($"{api.DeleteProducto}/{id}");

                if (responce.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el producto: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> EditarProducto(Producto modelo)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(modelo);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"{api.ActualizarProducto}/{modelo.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error al actualizar el producto: {response.ReasonPhrase}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción al actualizar el producto: {ex.Message}");
                return false;
            }
        }

    }
}

