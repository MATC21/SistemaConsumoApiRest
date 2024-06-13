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
    }
}