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
            this.ObtenerProducto = "/api/products/id";
            this.CrearProducto = "/api/products";
            this.ActualizarProducto = "/api/products/id";
            this.DeleteProducto = "/api/products/id";
        }
    }
}
