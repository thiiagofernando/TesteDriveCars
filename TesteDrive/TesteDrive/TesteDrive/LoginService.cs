using Newtonsoft.Json;
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

            using (var cliente = new HttpClient())
            {
                var camposFormulario = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>("email",login.email),
                        new KeyValuePair<string, string>("senha",login.senha)
                    });
                cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com/login");
                HttpResponseMessage resultado = null;
                try
                {
                    resultado = await cliente.PostAsync("/login", camposFormulario);
                }
                catch
                {
                    MessagingCenter.Send<LoginException>(new LoginException(@"Ocorreu um erro de comunicação com o servidor.
                                                                                        Por favor verifique a sua conexão e tente novamente mais tarde."), "FalhaLogin");
                }
                if (resultado.IsSuccessStatusCode)
                {
                   var conteudoResultado = await resultado.Content.ReadAsStringAsync();

                    var resultadologin = JsonConvert.DeserializeObject<ResultadoLogin>(conteudoResultado);

                    MessagingCenter.Send<Usuario>(resultadologin.usuario, "SucessoLogin");
                }
                else
                {
                    MessagingCenter.Send<LoginException>(new LoginException("Usuário ou Senha incorretos"), "FalhaLogin");
                }
            };

        }
    }

    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {

        }
    }
}
