using ControleSistema.Models;

namespace ControleSistema.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscaTodos(int usuarioId);
        ContatoModel ListarPorId(int id);
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
    }
}
