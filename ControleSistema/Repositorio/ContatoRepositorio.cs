using ControleSistema.Data;
using ControleSistema.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ControleSistema.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        private readonly ILogger<ContatoRepositorio> _logger;

        public ContatoRepositorio(BancoContext bancoContext, ILogger<ContatoRepositorio> logger)
        {
            _bancoContext = bancoContext;
            _logger = logger;
        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> BuscaTodos(int usuarioId)
        {
            return _bancoContext.Contatos.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            try
            {
                _bancoContext.Contatos.Add(contato);
                _bancoContext.SaveChanges();
                return contato;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar o contato.");
                throw;
            }
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            try
            {
                ContatoModel contatoDB = ListarPorId(contato.Id);

                if (contatoDB == null)
                {
                    _logger.LogError($"Contato com Id {contato.Id} não encontrado para atualização.");
                    throw new SystemException("Houve um Erro na Atualização do Contato!");
                }

                contatoDB.Nome = contato.Nome;
                contatoDB.Email = contato.Email;
                contatoDB.Telefone = contato.Telefone;

                _bancoContext.Contatos.Update(contatoDB);
                _bancoContext.SaveChanges();

                return contatoDB;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar o contato.");
                throw;
            }
        }

        public bool Apagar(int id)
        {
            try
            {
                ContatoModel contatoDB = ListarPorId(id);

                if (contatoDB == null)
                {
                    _logger.LogError($"Contato com Id {id} não encontrado para deleção.");
                    throw new SystemException("Houve um Erro na Deleção do Contato!");
                }

                _bancoContext.Contatos.Remove(contatoDB);
                _bancoContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao apagar o contato.");
                throw;
            }
        }
    }
}
