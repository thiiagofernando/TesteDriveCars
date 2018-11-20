using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using TesteDrive.Models;
using Xamarin.Forms;

namespace TesteDrive.ViewModels
{
    public class DetalheViewModel : BaseViewModel
    {
        public Veiculo Veiculo { get; set; }
        public string TextoFreioAbs
        {
            get
            {
                return string.Format("Freio ABS - R$ {0}", Veiculo.Freio_ABS);
            }
        }
        public string TextoArCondicionado
        {
            get
            {
                return string.Format("Ar Condicionado - R$ {0}", Veiculo.Ar_Condicionado);
            }
        }
        public string TextoMp3Player
        {
            get
            {
                return string.Format("MP3 Player - R$ {0}", Veiculo.MP3_Player);
            }
        }

        public bool TemFreioAbs
        {
            get
            {
                return Veiculo.TemFreioAbs;
            }
            set
            {
                Veiculo.TemFreioAbs = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }
        public bool TemArCondicionado
        {
            get
            {
                return Veiculo.TemArCondicionado;
            }
            set
            {
                Veiculo.TemArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }
        public bool TemMp3Player
        {
            get
            {
                return Veiculo.TemMp3Player;
            }
            set
            {
                Veiculo.TemMp3Player = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }
        public string ValorTotal
        {
            get
            {
                return Veiculo.PrecoTotalFromatado;
            }
        }

        public DetalheViewModel(Veiculo veiculo)
        {
            this.Veiculo = veiculo;
            ProximoCommand = new Command(()=> 
            {
                MessagingCenter.Send(veiculo,"Proximo");
            });
        }

        public ICommand ProximoCommand { get; set; }
    }
}
