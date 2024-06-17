using SistemaConsumoApiRest.Entidad;
using SistemaConsumoApiRest.Negocio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaConsumoApiRest.Views.ViewPartial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Editar : ContentPage
    {
        private Producto producto;
        private ObservableCollection<Producto> _productos;
        private ProductoNegocio _productoNegocio;
        public Editar(Entidad.Producto producto)
        {
            InitializeComponent();
            _productoNegocio = new ProductoNegocio();
            this.producto = producto;
            cargarProductos();

        }

        private void cargarProductos()
        {
            NombreEntry.Text = producto.Nombre;
            PrecioEntry.Text = producto.Precio.ToString();
            StockEntry.Text = producto.Stock.ToString();

        }

        private async void btnActualizarProducto_Clicked(object sender, EventArgs e)
        {
            // Validar entradas
            if (string.IsNullOrWhiteSpace(NombreEntry.Text) ||
                string.IsNullOrWhiteSpace(StockEntry.Text) ||
                string.IsNullOrWhiteSpace(PrecioEntry.Text))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos", "OK");
                return;
            }

            // Actualizar el objeto Producto
            producto.Nombre = NombreEntry.Text;
            producto.Stock = int.Parse(StockEntry.Text);
            producto.Precio = double.Parse(PrecioEntry.Text);

            // Llamar a la API para actualizar el producto
            bool productoActualizado = await _productoNegocio.EditarProducto(producto);

            if (productoActualizado == true)
            {
                await DisplayAlert("Éxito", "Producto actualizado exitosamente", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "No se pudo actualizar el producto. Verifique los datos y reintente.", "OK");
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
            }
        }
    }
}