using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SistemaConsumoApiRest.Model
{
    public class API
    {
        public string ListarProductos {  get; set; }
        public string ObtenerProducto { get; set; }
        public string CrearProducto { get; set; }
        public string ActualizarProducto { get; set; }
        public string DeleteProducto { get; set; }


        public API()
        {
            this.ListarProductos = "http://192.168.100.50:45455/api/Productos";
            this.ObtenerProducto = "http://192.168.100.50:45455/api/Productos/id";
            this.CrearProducto = "http://192.168.100.50:45455/api/Productos";
            this.ActualizarProducto = "http://192.168.100.50:45455/api/productos";
            this.DeleteProducto = "http://192.168.100.50:45455/api/productos";
        }
    }
}
