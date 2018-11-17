using System.Collections.Generic;
using Xamarin.Forms;

namespace TesteDrive.Views
{
    public class Veiculo
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string PrecoFormatado { get { return string.Format("R$ {0}", Preco); } }
    }

    public partial class ListagemView : ContentPage
    {
        public List<Veiculo> Veiculos { get; set; }

        public ListagemView()
        {
            InitializeComponent();
            this.Veiculos = new List<Veiculo>
            {
                new Veiculo{Nome ="Azira V6",Preco=60000},
                new Veiculo{Nome ="Fiesta 2.0",Preco=70000},
                new Veiculo{Nome ="HB20",Preco=80000}
            };
            this.BindingContext = this;
        }

        private void ListViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo)e.Item;
            Navigation.PushAsync(new DetalheView(veiculo));
        }
    }
}
