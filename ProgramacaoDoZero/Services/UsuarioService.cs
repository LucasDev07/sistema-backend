using System;
using ProgramacaoDoZero.Common;
using ProgramacaoDoZero.Entites;
using ProgramacaoDoZero.Models;
using ProgramacaoDoZero.Repositories;

namespace ProgramacaoDoZero.Services
{
    public class UsuarioService
    {
        private string _connectionString;

        public UsuarioService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario == null)
            {
                result.sucesso = false;
                result.mensagem = "Usuário ou senha inválidos";
            }
            else
            {
                if (usuario.Senha == senha)
                {
                    //faz login
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    result.sucesso = false;
                    result.mensagem = "Usuário ou senha inválidos"; 
                }
            }

            return result; 
         }

        public CadastroResult Cadastro(string nome, string sobrenome, string telefone, string email, string genero, string senha)
        {
            var result = new CadastroResult();

            var repositorio = new UsuarioRepository(_connectionString);

            var usuario = repositorio.ObterUsuarioPorEmail(email);

            if(usuario != null)
            {
                //usuário já existe
                result.sucesso = false;
                result.mensagem = "Usuário já existe no sistema";
            }
            else
            {
                //usuário não existe
                usuario = new UsuarioEntite();

                usuario.Nome = nome;
                usuario.Sobrenome = sobrenome;
                usuario.Telefone = telefone;
                usuario.Email = email;
                usuario.Genero = genero;
                usuario.Senha = senha;
                usuario.UsuarioGuid = Guid.NewGuid();

                var affectedRows = repositorio.Inserir(usuario);               
                
                if(affectedRows > 0)
                {
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    result.sucesso = false;
                    result.mensagem = "Não foi possível inserir o usuário";
                }
            }

            return result;
        }

        public EsqueceuSenhaResult EsqueceuSenha(string email)
        {
            var result = new EsqueceuSenhaResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if(usuario == null)
            {
                //usuário não existe
                result.sucesso = false;
                result.mensagem = "Usuário não existe para esse email";
            }
            else
            {
                //usuário existe
                var emailSender = new EmailSender();

                var assunto = "Recuperação de Senha";
                var corpo = "Sua senha é " + usuario.Senha;
                emailSender.EnviarEmail(assunto, corpo, usuario.Email);
            }

            return result;
        }

        public UsuarioEntite ObterUsuario(Guid usuarioGuid)
        {
            var usuario = new UsuarioRepository(_connectionString).ObterPorGuid(usuarioGuid);

            return usuario;
        }
    }
}
