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
        protected  override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento", async (msg) =>
             {
                 var confirma = await DisplayAlert("Salvar Agendamento"
                      , "Deseja mesmo enviar o agendamento ?"
                      , "Sim", "Não");

                 if (confirma)
                 {
                     this.viewModel.SalvarAgendamento();
                 }

             });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento",
                (msg)=> {
                    DisplayAlert("Agendamento","Agendamento Salvo com sucesso!!","OK");
                });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento",
                (msg) =>
                {
                    DisplayAlert("Agendamento", "Opss.. Falha ao agendar o teste drive", "OK");
                });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "FalhaAgendamento");
        }
    }
}