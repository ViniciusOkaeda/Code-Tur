using CodeTur.Dominio.Commands.Usuario;
using Xunit;

namespace CodeTur.Testes.Commands
{
    public class CriarUsuarioCommandTestes
    {
        [Fact]
        public void DeveRetornarErroSeDadosInvalidos()
        {
            var command = new CriarUsuarioCommand();

            command.Validar();

            Assert.True(command.Invalid, "Os dados estão preenchidos corretamente");
        }

        [Fact]
        public void DeveRetornarSucessoSeDadosValidosConstrutor()
        {
            var command = new CriarUsuarioCommand("Fernando", 
                                                  "email@email.com", 
                                                  "1234567", "", 
                                                  Comum.Enum.EnTipoUsuario.Comum
                                                  );

            command.Validar();

            Assert.True(command.Valid, "Os dados estão preenchidos corretamente");
        }

        [Fact]
        public void DeveRetornarSucessoSeDadosValidos()
        {
            var command = new CriarUsuarioCommand() {
                Nome = "Fernando",
                Email = "email@email.com",
                Senha = "1234567",
                TipoUsuario = Comum.Enum.EnTipoUsuario.Comum
            };

            //command.Nome = "Fernando";

            command.Validar();

            Assert.True(command.Valid, "Os dados estão preenchidos corretamente");
        }
    }
}
