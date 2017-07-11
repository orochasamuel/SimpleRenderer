using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleRenderer.Dtos.Boleto;

namespace SimpleRenderer.Tests
{
    [TestClass]
    public class MainTests
    {
        [TestMethod]
        public void IsNotNullTest()
        {
            var result =
                MainRenderer.Financial.GenerateBoletoHtml(new BoletoDto()
                {
                    LinhaDigitavel = "01234567890123456789012345678901234567890123456",
                    Banco = new BoletoDto.BancoDto()
                    {
                        Codigo = 999,
                        Digito = 9,
                        Descricao = "BANCO TESTE SA"
                    },
                    Pagador = new BoletoDto.PagadorDto()
                    {
                        Nome = "Beltrano Ciclano",
                        CpfCnpj = "000.000.000-00",
                        TipoLogradouro = "Rua",
                        Logradouro = "Imperador"
                    }
                });

            Assert.IsNotNull(result);
        }
    }
}
