using ControleSistema.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ControleSistema.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Obtenha a sessão do usuário logado
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            // Verifica se a sessão está vazia
            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                // Retorna a view "Deslogado" para usuários não autenticados
                return View("Deslogado");
            }

            // Se a sessão não está vazia, converte para o objeto UsuarioModel
            UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

            // Retorna a view "Default" para o usuário logado
            return View("Default", usuario);
        }
    }
}
