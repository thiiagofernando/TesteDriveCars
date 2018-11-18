using System.Collections.Generic;
using TesteDrive.Models;
using Xamarin.Forms;

namespace TesteDrive.Views
{
    public partial class ListagemView : ContentPage
    {
        

        public ListagemView()
        {
            InitializeComponent();
        }

        private void ListViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo)e.Item;
            Navigation.PushAsync(new DetalheView(veiculo));
        }
    }
}
