using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TesteDrive.Models;
using Xamarin.Forms;

namespace TesteDrive
{
    public class LoginService
    {
        public async Task FazerLogin(Login login)
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    var camposFormulario = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("email",login.email),
                        new KeyValuePair<string, string>("senha",login.senha)
                    });
                    cliente.BaseAddress = new Uri("http://aluracar.herokuapp.com/login");
                    var resultado = await cliente.PostAsync("/login", camposFormulario);
                    if (resultado.IsSuccessStatusCode)
                        MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");
                    else
                        MessagingCenter.Send<LoginException>(new LoginException("Usuário ou Senha incorretos"), "FalhaLogin");
                };
            }
            catch
            {
                MessagingCenter.Send<LoginException>(new LoginException(@"Ocorreu um erro de comunicação com o servidor.
                                                                                        Por favor verifique a sua conexão e tente novamente mais tarde."), "FalhaLogin");
            }
        }
    }

    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {

        }
    }
}
