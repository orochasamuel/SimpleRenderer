using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleRenderer.Dtos.Boleto
{
    public class BoletoDto
    {
        public class BancoDto
        {
            public int Codigo { get; set; }
            public int Digito { get; set; }
            public string Descricao { get; set; }
            public override string ToString()
            {
                return string.Format($"{Codigo}-{Digito}");
            }
        }

        public class BeneficiarioDto
        {
            public string Nome { get; set; }
            public string CpfCnpj { get; set; }
            public string TipoLogradouro { get; set; }
            public string Logradouro { get; set; }
            public string Complemento { get; set; }
            public string Distrito { get; set; }
            public string Cidade { get; set; }
            public string Uf { get; set; }
            public string Cep { get; set; }
        }

        public class CarteiraDto
        {
            public string Codigo { get; set; }
            public string Tipo { get; set; }
            public string Descricao { get; set; }
            public string Variacao { get; set; }
            public override string ToString()
            {
                return
                    string.Format($"{(string.IsNullOrEmpty(Variacao) ? Codigo : string.Format($"{Codigo}-{Variacao}"))}");
            }
        }

        public class ContaBancariaDto
        {
            public string CodAgencia { get; set; }
            public string DigitoAgencia { get; set; }
            public string CodConta { get; set; }
            public string DigitoConta { get; set; }
            public string OperacaoConta { get; set; }

            public string ContaComDigito
            {
                get
                {
                    return string.Format($"{CodConta}-{DigitoConta}");
                }
            }

            public override string ToString()
            {
                return string.Format($"{CodAgencia} / {ContaComDigito}");
            }
        }

        public class PagadorDto
        {
            public string Nome { get; set; }
            public string CpfCnpj { get; set; }
            public string TipoLogradouro { get; set; }
            public string Logradouro { get; set; }
            public string Complemento { get; set; }
            public string Distrito { get; set; }
            public string Cidade { get; set; }
            public string Uf { get; set; }
            public string Cep { get; set; }
            public override string ToString()
            {
                return
                    string.Format(
                        $"{Nome} / {CpfCnpj}<br />{TipoLogradouro} {Logradouro} {Complemento} {Distrito} / {Cidade} / {Uf} / {Cep}");
            }
        }

        public class SacadorDto
        {
            public string Nome { get; set; }
            public string CpfCnpj { get; set; }
            public string TipoLogradouro { get; set; }
            public string Logradouro { get; set; }
            public string Complemento { get; set; }
            public string Distrito { get; set; }
            public string Cidade { get; set; }
            public string Uf { get; set; }
            public string Cep { get; set; }
            public override string ToString()
            {
                return
                    string.Format(
                        $"{Nome} / {CpfCnpj}<br />{TipoLogradouro} {Logradouro} {Complemento} {Distrito} / {Cidade} / {Uf} / {Cep}");
            }
        }

        public class ValoresDto
        {
            public decimal VlDoc { get; set; }
            public decimal VlDesc { get; set; }
            public decimal VlJurM { get; set; }
            public decimal VlCobrado { get; set; }
        }

        public class InstrucoesDto
        {
            public InstrucoesDto()
            {
                Instrucoes = new List<InstrucaoDto>();
            }

            public List<InstrucaoDto> Instrucoes { get; set; }

            public class InstrucaoDto
            {
                public string Instrucao { get; set; }
            }
        }

        public string CodigoBarras { get; set; }

        public string CodigoBarras64 { get; set; }

        public string LinhaDigitavel { get; set; }

        public string LocalPagamento { get; set; }

        public DateTime DataVencimento { get; set; }

        public string NossoNumero { get; set; }

        public DateTime DataDocumento { get; set; }

        public string NumeroDocumento { get; set; }

        public string EspecieDoc { get; set; }

        public bool Aceite { get; set; }

        public DateTime DataProcessamento { get; set; }

        public string Especie { get; set; }

        public decimal Quantidade { get; set; }

        public decimal Valor { get; set; }

        public BancoDto Banco { get; set; }

        public BeneficiarioDto Beneficiario { get; set; }

        public CarteiraDto Carteira { get; set; }

        public ContaBancariaDto ContaBancaria { get; set; }

        public InstrucoesDto Instrucoes { get; set; }

        public PagadorDto Pagador { get; set; }

        public SacadorDto Sacador { get; set; }

        public ValoresDto Valores { get; set; }
    }
}
