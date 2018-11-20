using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDrive.Models
{
    public class ListagemVeiculos
    {
        public List<Veiculo> Veiculos { get; set; }
        public ListagemVeiculos()
        {
            this.Veiculos = new List<Veiculo>
            {
                new Veiculo{Nome ="Azira V6",Preco=60000},
                new Veiculo{Nome ="Fiesta 2.0",Preco=70000},
                new Veiculo{Nome ="HB20",Preco=80000},
                new Veiculo{Nome ="Hilux 4x4",Preco=810000}
            };
        }
    }
}
