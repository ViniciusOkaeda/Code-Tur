using CodeTur.Comum.Enum;
using CodeTur.Dominio.Entidades;
using Xunit;

namespace CodeTur.Testes.Entidades
{
    public class UsuarioTestes
    {
        [Fact]
        public void DeveRetornarErroSeUsuarioInvalido()
        {
            var usuario = new Usuario("", "fernando.guerra@corujsdev.com.br", "123456", EnTipoUsuario.Comum);
            //Espera que o usuário seja invalido
            Assert.True(usuario.Invalid, "Usuário é válido");
        }

        [Fact]
        public void DeveRetornarErroSeEmailInvalido()
        {
            var usuario = new Usuario("", "fernando.guerracorujsdev.com.br", "123456", EnTipoUsuario.Comum);
            //Espera que o usuário seja invalido
            Assert.True(usuario.Invalid, "Usuário é válido");
        }

        [Fact]
        public void DeveRetornarSucessoSeUsuarioInvalido()
        {
            var usuario = new Usuario("Fernando Henrique", "fernando.guerra@corujsdev.com.br", "123456", EnTipoUsuario.Comum);
            usuario.AlterarUsuario("", "emailemail.com");

            //Espera que o usuário seja invalido
            Assert.True(usuario.Invalid, "Usuário é inválido");
        }

        [Fact]
        public void DeveRetornarErroSeTelefoneUsuarioInvalido()
        {
            var usuario = new Usuario("Fernando Henrique", "fernando.guerra@corujsdev.com.br", "123456", EnTipoUsuario.Comum);
            usuario.AdicionarTelefone("114352");

            //Espera que o usuário seja invalido
            Assert.True(usuario.Invalid, "Telefone é válido");
        }

        [Fact]
        public void DeveRetornarSucessoSeTelefoneUsuarioInvalido()
        {
            var usuario = new Usuario("Fernando Henrique", "fernando.guerra@corujsdev.com.br", "123456", EnTipoUsuario.Comum);
            usuario.AdicionarTelefone("11987656543");
            

            //Espera que o usuário seja invalido
            Assert.True(usuario.Valid, "Telefone é inválido");
        }
    }
}
