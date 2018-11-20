using System.Collections.Generic;
using TesteDrive.Models;
using TesteDrive.ViewModels;
using Xamarin.Forms;

namespace TesteDrive.Views
{
    public partial class ListagemView : ContentPage
    {

        public ListagemVeiwModel viewModel { get; set; }
        public ListagemView()
        {
            InitializeComponent();
            this.viewModel = new ListagemVeiwModel();
            this.BindingContext = this.viewModel;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado",
                (msg) =>
                {
                    Navigation.PushAsync(new DetalheView(msg));
                });
            await this.viewModel.GetVeiculos();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }
    }
}
