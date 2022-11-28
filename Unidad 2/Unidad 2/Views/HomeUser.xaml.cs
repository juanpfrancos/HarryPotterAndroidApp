using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using Unidad_2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Unidad_2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeUser : ContentPage
    {
        public HomeUser()
        {
            InitializeComponent();
        }
        private async void Get_Character(object sender, EventArgs e)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://hp-api.herokuapp.com/api/characters");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonSerializer.Deserialize<List<HarryPotterModel>>(content);
                Character.ItemsSource = resultado;
                await Application.Current.MainPage.DisplayAlert("All Character", "Now you can show all characters of HP ⚡🏰", "Thanks");
            }
        }
    }
}