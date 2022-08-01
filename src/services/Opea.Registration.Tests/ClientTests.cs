using Opea.Registration.Business.Domain.Client;
using System;
using Xunit;

namespace Opea.Registration.Tests
{
    public class ClientTests
    {
        [Fact]
        public void Client_Validate_Return_Exceptions()
        {
            var ex = Assert.Throws<Exception>(() =>
                new Client(null, Guid.NewGuid(), "", 1));

            Assert.Equal("O campo nome é obrigatório", ex.Message);

            ex = Assert.Throws<Exception>(() =>
                new Client(null, Guid.NewGuid(), "Nova Empresa", 0));

            Assert.Equal("O campo Porte da Empresa é obrigatório", ex.Message);
        }

    }
}