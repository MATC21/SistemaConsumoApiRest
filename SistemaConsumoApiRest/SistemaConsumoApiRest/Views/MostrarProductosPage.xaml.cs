using SistemaConsumoApiRest.Entidad;
using SistemaConsumoApiRest.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SistemaConsumoApiRest.Negocio;
using SistemaConsumoApiRest.Views.ViewPartial;

namespace SistemaConsumoApiRest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostrarProductosPage : ContentPage
    {
        private ObservableCollection<Producto> _productos;
        private ProductoNegocio _productoNegocio;
        public MostrarProductosPage()
        {
            InitializeComponent();
            _productoNegocio = new ProductoNegocio();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CargarProductos();
        }

        private async Task CargarProductos()
        {
            var productos = await _productoNegocio.ObtenerTodosLosProductos();
            if (productos != null)
            {
                _productos = new ObservableCollection<Producto>(productos);
                ProductoListaview.ItemsSource = _productos;
            }
            else
            {
                await DisplayAlert("Error", "No se pudieron cargar los productos", "OK");
            }
        }

        private async void btnEditar_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var productos = button?.BindingContext as Producto;

            if(productos != null)
            {
                await Navigation.PushAsync(new Editar(productos));
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var producto = button?.BindingContext as Producto;

            if (producto != null)
            {
                bool confirm = await DisplayAlert("Confirmar", $"¿Está seguro de eliminar el producto {producto.Nombre}?", "Sí", "No");

                if (confirm)
                {
                    bool eliminado = await _productoNegocio.EliminarProducto(producto.Id);

                    if (eliminado)
                    {
                        _productos.Remove(producto);
                        await DisplayAlert("Exito", "Producto eliminado correctamente", "Ok");
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo eliminar el producto", "Ok");
                    }
                }

            }
        }
    }
}
