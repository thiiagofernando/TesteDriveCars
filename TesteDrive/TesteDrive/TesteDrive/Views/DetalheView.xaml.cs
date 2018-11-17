using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheView : ContentPage
	{
        public Veiculo Veiculo { get; set; }
        public DetalheView (Veiculo veiculo)
		{
			InitializeComponent ();
            this.Veiculo = veiculo;
            this.BindingContext = this;
		}

        private void ButtonProximo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(this.Veiculo));
        }
    }
}