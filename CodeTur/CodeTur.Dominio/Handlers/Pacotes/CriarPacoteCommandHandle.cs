using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Dominio.Commands.Pacote;
using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using System;

namespace CodeTur.Dominio.Handlers.Pacotes
{
    public class CriarPacoteCommandHandle : IHandlerCommand<CriarPacoteCommand>
    {
        private readonly IPacoteRepositorio _pacoteRepositorio;

        public CriarPacoteCommandHandle(IPacoteRepositorio pacoteRepositorio)
        {
            _pacoteRepositorio = pacoteRepositorio;
        }

        public ICommandResult Handle(CriarPacoteCommand command)
        {
            //Validar dados
            command.Validar();

            if(command.Invalid)
                return new GenericCommandResult(true, "Dados inválidos", command.Notifications);

            //Verifica se existe pacote com o mesmo titulo
            var pacoteexiste = _pacoteRepositorio.BuscarPorTitulo(command.Titulo);

            if(pacoteexiste != null)
                return new GenericCommandResult(true, "Titulo do pacote já cadastrado", null);

            //Gerar instancia do Pacote
            var pacote = new Pacote(command.Titulo, command.Descricao, command.Imagem, command.Ativo);

            if(pacote.Invalid)
                return new GenericCommandResult(true, "Dados inválidos", pacote.Notifications);

            //Adicionar pacote
            _pacoteRepositorio.Adicionar(pacote);

            //Retornar sucesso
            return new GenericCommandResult(true, "Pacote criado", pacote);

        }
    }
}
