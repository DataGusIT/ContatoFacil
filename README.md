
# ContatoFácil

> Uma plataforma moderna e intuitiva para gestão de contatos

[![Status](https://img.shields.io/badge/Status-Finalizado-success)](https://github.com/seu-usuario/contatofacil)
[![License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-6.0+-512BD4)](https://dotnet.microsoft.com/)
[![Contributors](https://img.shields.io/github/contributors/seu-usuario/contatofacil)](https://github.com/seu-usuario/contatofacil/graphs/contributors)

## Sobre

ContatoFácil é uma solução completa para gerenciamento de contatos, desenvolvida com foco em simplicidade e eficiência. A aplicação oferece uma interface moderna e recursos avançados para organizar suas conexões profissionais e pessoais.

## Principais Funcionalidades

- **Gestão Completa de Contatos**: Criação, edição e exclusão com interface intuitiva
- **Sistema de Autenticação**: Login seguro com controle de acesso
- **Interface Responsiva**: Design adaptável para desktop e mobile
- **Criptografia de Dados**: Proteção avançada das informações sensíveis
- **Busca Avançada**: Encontre contatos rapidamente com filtros inteligentes

## Tecnologias

### Backend
- **C#** - Linguagem principal
- **ASP.NET Core 6.0** - Framework web
- **Entity Framework Core** - ORM
- **SQL Server** - Banco de dados

### Frontend
- **HTML5** - Estrutura
- **CSS3** - Estilização
- **JavaScript** - Interatividade
- **Bootstrap** - Framework CSS

### Ferramentas
- **Visual Studio 2022** - IDE
- **Git** - Controle de versão

## Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) ou superior
- [SQL Server](https://www.microsoft.com/sql-server) (Local ou Express)
- [Git](https://git-scm.com/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)

## Instalação

1. **Clone o repositório**
   ```bash
   git clone https://github.com/seu-usuario/contatofacil.git
   cd contatofacil
   ```

2. **Restaure as dependências**
   ```bash
   dotnet restore
   ```

3. **Configure o banco de dados**
   
   Edite o arquivo `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ContatoFacilDB;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
   ```

4. **Execute as migrações**
   ```bash
   dotnet ef database update
   ```

5. **Execute a aplicação**
   ```bash
   dotnet run
   ```

6. **Acesse no navegador**
   ```
   https://localhost:5001
   ```

## Estrutura do Projeto

```
ContatoFácil/
├── Controllers/         # Controladores MVC
├── Models/             # Modelos de dados
├── Views/              # Views do MVC
├── wwwroot/            # Arquivos estáticos
├── Data/               # Contexto do banco de dados
├── Services/           # Serviços da aplicação
└── Migrations/         # Migrações do EF Core
```

## Contribuição

Contribuições são bem-vindas! Para contribuir:

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

### Diretrizes para Contribuição

- Siga os padrões de código existentes
- Escreva testes para novas funcionalidades
- Documente mudanças no README quando necessário
- Use mensagens de commit descritivas

## Roadmap

- [ ] Sistema de importação/exportação de contatos
- [ ] Integração com APIs de terceiros
- [ ] Aplicativo mobile
- [ ] Sincronização em nuvem
- [ ] Relatórios e analytics

## Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo [LICENSE](LICENSE) para detalhes.

## Contato

**Gustavo Moreno**

- Email: [g.moreno.souza05@gmail.com](mailto:g.moreno.souza05@gmail.com)
- LinkedIn: [Gustavo Moreno](https://www.linkedin.com/in/gustavo-moreno-8a925b26a/)

---

<div align="center">
  Feito por Gustavo Moreno e Fábio Rigote
</div>
