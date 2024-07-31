using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProgramacaoDoZero.Controllers
{
    [Route("api/aula8")]
    [ApiController]
    public class Aula8Controller : ControllerBase
    {
        [Route("olaMundo")]
        [HttpGet]
        public string OláMundo()
        {
            var mensagem = "Olá mundo via API";

            return mensagem;
        }

        [Route("olaMundoPersonalizado")]
        [HttpGet]
        public IActionResult OlaMundoPersonalizado(string nome)
        {
            var mensagem = "Olá mundo via API " + nome;
           
            return Ok(mensagem);
        }

        [Route("somar")]
        [HttpGet]
        public string Somar(int valor1, int valor2)
        {
            var soma = valor1 + valor2;

            var mensagem = "A soma é " + soma;

            return mensagem;
        } 

        [Route("calculoMedia")]
        [HttpGet]
        public string calcularMedia(int valor1, int valor2)
        {
            var soma = valor1 + valor2;

            var media = soma / 2;

            var mensagem = "A média é: " + media;

            return mensagem;
        }

        [Route("areaEPrecoTerreno")]
        [HttpGet]
        public string terreno(float largura, float comprimento, float valorm2)
        {
            var area = largura * comprimento;

            var precoTerreno = area * valorm2;

            var mensagem = "A área do terreno é de " + area + "m2 " + " e o valor do terreno é " + precoTerreno;

            return mensagem;
        }

        [Route("troco")]
        [HttpGet]
        public string trocoDoCliente(float precoProduto, float unidadesCompradas, float valorCliente)
        {
            var valorDaCompra = precoProduto * unidadesCompradas;

            var troco = valorCliente - valorDaCompra;

            var mensagem = "O troco do cliente é de R$ " + troco;

            return mensagem;
        }
        //testar no postman
        [Route("salario")]
        [HttpGet]
        public string salarioFuncionario(string nome, float recebePHora, float horasMensais)
        {

            var salario = recebePHora * horasMensais;

            var mensagem = "O salário de " + nome + " é R$: " + salario;

            return mensagem;
        }

        [Route("consumoVeiculo")]
        [HttpGet]
        public string ConsumoMedio(float distanciaPercorridaKm, float combustivelGasto)
        {
            var consumoMedio = distanciaPercorridaKm / combustivelGasto;

            var mensagem = "O consumo médio do veículo é de " + consumoMedio + "km por litro.";

            return mensagem; 

        }
    }
}
