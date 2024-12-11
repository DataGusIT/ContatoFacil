using ControleSistema.Filters;
using ControleSistema.Helper;
using ControleSistema.Models;
using ControleSistema.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ControleSistema.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        private readonly ISessao _sessao;
        private readonly ILogger<ContatoController> _logger;


        public ContatoController(IContatoRepositorio contatoRepositorio, ISessao sessao, ILogger<ContatoController> logger)
        {
            _contatoRepositorio = contatoRepositorio;
            _sessao = sessao;
            _logger = logger;

        }

        public IActionResult Index()
        {
            UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            List<ContatoModel> contatos = _contatoRepositorio.BuscaTodos(usuarioLogado.Id);

            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);

            if (contato == null || contato.UsuarioId != usuarioLogado.Id)
            {
                TempData["MensagemErro"] = "Você não tem permissão para editar este contato.";
                return RedirectToAction("Index");
            }

            return View(contato);
        }


        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu contato!";
                }

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar([Bind("Nome,Email,Telefone,UsuarioId")] ContatoModel contato)
        {
            try
            {
                UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();

                if (usuarioLogado == null || usuarioLogado.Id == 0)
                {
                    TempData["MensagemErro"] = "Erro: Usuário não está autenticado ou sessão inválida.";
                    return RedirectToAction("Index");
                }

                contato.UsuarioId = usuarioLogado.Id;  // Atribui o ID do usuário logado ao contato

                if (!ModelState.IsValid)
                {
                    TempData["MensagemErro"] = "Por favor, verifique os campos inseridos.";
                    return View(contato);
                }

                _contatoRepositorio.Adicionar(contato);  // Adiciona o contato no repositório

                TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                _logger.LogError(erro, "Erro ao tentar criar um novo contato para o usuário {UsuarioId}: {Mensagem}", contato.UsuarioId, erro.Message);
                TempData["MensagemErro"] = $"Ops, não foi possível cadastrar seu contato. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();

                    // Certifique-se de que o contato a ser atualizado pertence ao usuário logado
                    ContatoModel contatoExistente = _contatoRepositorio.ListarPorId(contato.Id);
                    if (contatoExistente == null || contatoExistente.UsuarioId != usuarioLogado.Id)
                    {
                        TempData["MensagemErro"] = "Você não tem permissão para alterar este contato.";
                        return RedirectToAction("Index");
                    }

                    contato.UsuarioId = usuarioLogado.Id;
                    _contatoRepositorio.Atualizar(contato);

                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar contato.");
                TempData["MensagemErro"] = $"Ops, não foi possível atualizar seu contato, tente novamente. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public IActionResult ObterTodos()
        {
            try
            {
                UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                var contatos = _contatoRepositorio.BuscaTodos(usuarioLogado.Id);
                return Json(contatos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter contatos.");
                return StatusCode(500, new { mensagem = $"Erro ao obter contatos: {ex.Message}" });
            }
        }
    }
}
