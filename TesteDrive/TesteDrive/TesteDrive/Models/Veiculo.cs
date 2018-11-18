using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDrive.Models
{
    public class Veiculo
    {
        public const int Freio_ABS = 800;
        public const int Ar_Condicionado = 1000;
        public const int MP3_Player = 500;

        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string PrecoFormatado { get { return string.Format("R$ {0}", Preco); } }

        public bool TemFreioAbs { get; set; }
        public bool TemArCondicionado { get; set; }
        public bool TemMp3Player { get; set; }

        public string PrecoTotalFromatado
        {
            get
            {
                return string.Format("Valor Total: R$ {0}",
                       Preco
                    + (TemFreioAbs ? Freio_ABS : 0)
                    + (TemArCondicionado ? Ar_Condicionado : 0)
                    + (TemMp3Player ? MP3_Player : 0));
            }
            
        }
    }
}
