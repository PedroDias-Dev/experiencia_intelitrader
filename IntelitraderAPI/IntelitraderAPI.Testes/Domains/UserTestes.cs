using IntelitraderAPI.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntelitraderAPI.Testes.Domains
{
    public class UserTestes
    {
        //  testes do metodo Validar com Flunt

        [Fact]
        public void DeveRetornarErroSeUsuarioValido()
        {
            // sem o primeiro nome
            var user = new User() { firstName = "a", age = 19, surName = "" };
            user.Validar(user);

            // assert.false 
            Assert.False(user.Invalid, "Usuário é inválido!");
        }

        [Fact]
        public void DeveRetornarErroSeUsuarioValido2()
        {
            // sem a idade
            var user2 = new User() { firstName = "", age = 0, surName = "Dias" };
            user2.Validar(user2);
            Assert.False(user2.Invalid, "Usuário 2 é inválido!");
        }

        [Fact]
        public void DeveRetornarErroSeUsuarioValido3()
        { 
            // sem o segundo nome
            var user3 = new User() { firstName = "asasdasd", age = 19, surName = "a" };
            user3.Validar(user3);
            Assert.False(user3.Invalid, "Usuário 3 é inválido!");
        }
    }
}
