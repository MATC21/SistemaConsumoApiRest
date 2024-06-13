using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaConsumoApiRest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detail : ContentPage
    {
        public Detail()
        {
            InitializeComponent();
        }

        private async void btnIrApi_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync("http://192.168.100.50:45455/api/Productos");
        }
    }
}