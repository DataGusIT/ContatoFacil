using ControleSistema.Models;
using ControleSistema.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleSistema.Controllers
{

    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IContatoRepositorio _contatoRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio,
                                  IContatoRepositorio contatoRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _contatoRepositorio = contatoRepositorio;
        }

        // Lista todos os usuários
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscaTodos();
            return View(usuarios);
        }

        // Exibe o formulário de cadastro
        public IActionResult Cadastro()
        {
            return View();
        }

        // Método para cadastrar um usuário
        [HttpPost]
        public IActionResult Cadastrar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Verifica se o email já está cadastrado
                    if (_usuarioRepositorio.EmailExiste(usuario.Email))
                    {
                        ModelState.AddModelError("Email", "O email informado já está em uso. Por favor, utilize outro email.");
                        return View("Cadastro", usuario);
                    }

                    // Verifica se o nome de login (usuário) já está cadastrado
                    if (_usuarioRepositorio.LoginExiste(usuario.Login))
                    {
                        ModelState.AddModelError("Login", "O nome de usuário informado já está em uso. Por favor, utilize outro nome de usuário.");
                        return View("Cadastro", usuario);
                    }

                    _usuarioRepositorio.Adicionar(usuario);

                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso! Faça login para acessar sua conta.";
                    return RedirectToAction("Index", "Login");
                }

                return View("Cadastro", usuario);
            }
            catch (Exception erro)
            {
                ModelState.AddModelError(string.Empty, $"Ops, não conseguimos realizar seu cadastro, tente novamente. Detalhe do erro: {erro.Message}");
                return View("Cadastro", usuario);
            }
        }



        // Exibe o formulário de criação (opcional)
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);

                    // Define a mensagem de sucesso
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";

                    // Redireciona para a página de login
                    return RedirectToAction("Index", "Usuario");
                }
                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível cadastrar seu usuário, tente novamente. Detalhes do erro: {erro.Message}";
                return View(usuario);
            }
        }

        // Exibe o formulário de edição
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarPorID(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                    };

                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", usuarioSemSenhaModel);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível atualizar o usuário, tente novamente. Detalhes do erro: {erro.Message}";
                return View("Editar", usuarioSemSenhaModel);
            }
        }

        // Exibe a confirmação de exclusão
        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarPorID(id);
            return View(usuario);
        }

        // Método para apagar um usuário
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar o usuário!";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar o usuário. Mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult ListarContatosPorUsuarioId(int id)
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscaTodos(id);
            return PartialView("_ContatosUsuario", contatos);
        }
    }
}
