using ControleSistema.Models;

namespace ControleSistema.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorEmail(string email);
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel BuscarPorEmailELogin(string email, string login);
        List<UsuarioModel> BuscaTodos();
        UsuarioModel BuscarPorID(int id);
        UsuarioModel ListarPorId(int id);
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel);

        bool Apagar(int id);

        //  método para verificar se o email já existe
        bool EmailExiste(string email);
        // Novo método para verificar se o nome de usuário já existe
        bool LoginExiste(string nome);
    }
}
