using LoginProject.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LoginProject.Librarys.Email
{
    public class GerenciarEmail
    {
        private SmtpClient _smtp;
        private IConfiguration _configuration;

        public GerenciarEmail(SmtpClient smtp, IConfiguration configuration)
        {
            _smtp = smtp;
            _configuration = configuration;
        }
        public void EnviarSenhaParaUsuarioPorEmail(Usuario usuario, string senha)
        {
            string corpoMgs = string.Format("<h2> Usuário - Login Project </h2>" +
                "Sua senha é:" +
                "<h3>{0}</h3>", senha
            );

            MailMessage mensagem = new MailMessage();

            mensagem.From = new MailAddress(_configuration.GetValue<string>("Email:Username"));
            
            mensagem.To.Add(usuario.Email);
            mensagem.Subject = "Usuário - Login Project - Senha do Usuário";
            mensagem.Body = corpoMgs; 
            mensagem.IsBodyHtml = true; 

            _smtp.Send(mensagem); 
        }
    }
}
