using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Input;
using TesteDrive.Models;
using Xamarin.Forms;

namespace TesteDrive.ViewModels
{
    public class LoginViewModel
    {
        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        private string senha;

        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }
        public ICommand EntrarCommand { get; private set; }
        public LoginViewModel()
        {
            EntrarCommand = new Command(async () =>
            {
                var fazerlogin = new LoginService();
                await fazerlogin.FazerLogin(new Login(usuario,senha));
            }, () =>
             {
                 return !string.IsNullOrEmpty(usuario)
                          && !string.IsNullOrEmpty(senha);
             });

        }

    }
}
