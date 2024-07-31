using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProgramacaoDoZero.Models;
using ProgramacaoDoZero.Services;

namespace ProgramacaoDoZero.Controllers
{
    [Route("api/usuario")]
    [ApiController ]
    public class UsuarioController : ControllerBase
    {
        private IConfiguration _configuration;

        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("login")]
        [HttpPost]
        public LoginResult Login(LoginRequest request)
        {
            var result = new LoginResult();

            if(request == null)
            {
                result.sucesso = false;
                result.mensagem = "Parâmetro request veio nulo";
            }
            else if(request.email == "")
            {
                result.sucesso = false;
                result.mensagem = "E-mail obrigatório";
            }
            else if(request.senha == "")
            {
                result.sucesso = false;
                result.mensagem = "Senha obrigatória";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.Login(request.email, request.senha);
            } 
            
            return result;
        }

        [Route("cadastro")]
        [HttpPost]
        public CadastroResult Cadastro(CadastroRequest request)
        {
            var result = new CadastroResult();

            if (request == null ||
                 string.IsNullOrWhiteSpace(request.nome) ||
                 string.IsNullOrWhiteSpace(request.sobrenome) ||
                 string.IsNullOrWhiteSpace(request.telefone) ||
                 string.IsNullOrWhiteSpace(request.genero) ||
                 string.IsNullOrWhiteSpace(request.email) ||
                 string.IsNullOrWhiteSpace(request.senha))
            {
                result.sucesso = false;
                result.mensagem = "Todos os campos são obrigatórios";

                return (result);
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.Cadastro(request.nome, request.sobrenome,
                    request.telefone, request.email, request.genero, request.senha);
            }

            return result;
        }

        [Route("esqueceuSenha")]
        [HttpPost]
        public EsqueceuSenhaResult EsqueceuSenha(EsqueceuSenhaRequest request)
        {
            var result = new EsqueceuSenhaResult();

            if (request == null ||
                string.IsNullOrWhiteSpace(request.email))
            {
                result.mensagem = "Email obrigatório";

                return result;
            }

            var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

             result = new UsuarioService(connectionString).EsqueceuSenha(request.email);    
       
            return result;
        }

        [Route("obterUsuario")]
        [HttpGet]
        public ObterUsuarioResult ObterUsuario(Guid usuarioGuid)
        {
            var result = new ObterUsuarioResult();

            if(usuarioGuid == null)
            {
                result.mensagem = "Usuário Guid Vazio";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

                var usuarioService = new UsuarioService(connectionString).ObterUsuario(usuarioGuid); 

                if (usuarioService == null)
                {
                    result.mensagem = "Usuário não existe";
                }
                else
                {
                    result.sucesso = true;
                    result.nome = usuarioService.Nome;
                }
            }
           
            return result;
        }    
    }
}
