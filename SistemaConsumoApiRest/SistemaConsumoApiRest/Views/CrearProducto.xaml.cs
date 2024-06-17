using SistemaConsumoApiRest.Entidad;
using SistemaConsumoApiRest.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaConsumoApiRest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrearProducto : ContentPage
    {
        private ProductoNegocio _productoNegocio;
        public CrearProducto()
        {
            InitializeComponent();
            _productoNegocio = new ProductoNegocio();
        }

        private async void btnCrearProducto_Clicked(object sender, EventArgs e)
        {
            // Validar entradas
            if (string.IsNullOrWhiteSpace(NombreEntry.Text) ||
                string.IsNullOrWhiteSpace(StockEntry.Text) ||
                string.IsNullOrWhiteSpace(PrecioEntry.Text))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos", "OK");
                return;
            }

            // Crear objeto Producto
            var nuevoProducto = new Producto
            {
                Nombre = NombreEntry.Text,
                Stock = int.Parse(StockEntry.Text),
                Precio = double.Parse(PrecioEntry.Text)
            };

            // Llamar a la API para crear el producto
            var productoCreado = await _productoNegocio.CrearProducto(nuevoProducto);

            if (productoCreado != null)
            {
                await DisplayAlert("Éxito", "Producto creado exitosamente", "OK");
                // Navegar a la página anterior o a la lista de productos
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "No se pudo crear el producto", "OK");
            }
        }

        private void PrecioEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(e.NewTextValue, out double result))
            {
                // El texto ingresado es un número válido
                ((Entry)sender).TextColor = Color.Default;
            }
            else
            {
                // El texto ingresado no es un número válido
                ((Entry)sender).TextColor = Color.Red;
                DisplayAlert("Éxito", "Ingresa un valor valido", "OK");
            }
        }
    }
}