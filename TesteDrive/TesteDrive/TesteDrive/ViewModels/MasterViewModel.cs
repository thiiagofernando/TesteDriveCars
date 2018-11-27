using TesteDrive.Models;

namespace TesteDrive.ViewModels
{
    public class MasterViewModel
    {
        public string Nome
        {
            get { return this.usuario.nome ; }
            set { this.usuario.nome = value; }
        }

        public string Email
        {
            get { return this.usuario.email; }
            set { this.usuario.email = value; }
        }

        private readonly Usuario usuario;
        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;
        }

    }
}
