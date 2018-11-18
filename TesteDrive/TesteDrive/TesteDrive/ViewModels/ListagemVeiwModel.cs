using System;
using System.Collections.Generic;
using System.Text;
using TesteDrive.Models;

namespace TesteDrive.ViewModels
{
    public class ListagemVeiwModel
    {
        public List<Veiculo> Veiculos { get; set; }

        public ListagemVeiwModel()
        {
            this.Veiculos = new ListagemVeiculos().Veiculos;
        }
    }
}
