using System;
using TesteDrive.Models;
using TesteDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel viewModel { get; set; }

        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.viewModel = new AgendamentoViewModel(veiculo);
            this.BindingContext = this.viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento", (msg) =>
             {
                 DisplayAlert("Agendamento",
                     string.Format(
                     @"
                     Veiculo : {0}
                     Nome: {1}
                     Fone: {2}
                     E-mail: {3}
                     Data Agendamento: {4}
                     Hora Agendamento: {5}",
                     viewModel.Agendamento.Veiculo.Nome,
                     viewModel.Agendamento.Nome,
                     viewModel.Agendamento.Fone,
                     viewModel.Agendamento.Email,
                     viewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyyy"),
                     viewModel.Agendamento.HoraAgendamento),
                     "Ok");
             });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
        }
    }
}