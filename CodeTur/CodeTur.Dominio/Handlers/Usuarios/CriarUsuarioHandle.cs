using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Util;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using Flunt.Notifications;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    public class CriarUsuarioHandle : Notifiable, IHandlerCommand<CriarUsuarioCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public CriarUsuarioHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handle(CriarUsuarioCommand command)
        {
            //Fail Fast Validation
            //Verifica se o command recebido é válido
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            var usuarioExiste = _usuarioRepositorio.BuscarPorEmail(command.Email);

            if (usuarioExiste != null)
                return new GenericCommandResult(false, "E-mail já cadastrado, informe outro e-mail", null);

            //TODO: Criptografar Senha
            command.Senha = Senha.Criptografar(command.Senha);

            //TODO: Salvar no Banco
            var usuario = new Usuario(command.Nome, command.Email, command.Senha, command.TipoUsuario);
            //Verifica se foi passado o telefone, caso sim inclui o mesmo
            if (!string.IsNullOrEmpty(command.Telefone))
                usuario.AdicionarTelefone(command.Telefone);

            if (usuario.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", usuario.Notifications);

            _usuarioRepositorio.Adicionar(usuario);

            //TODO : Enviar Email de boas Vindas para o meu usuário
            //Desafio SendGrid

            return new GenericCommandResult(true, "Usuário Criado", null);
        }
    }
}
