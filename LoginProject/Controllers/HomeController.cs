using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginProject.Models;
using LoginProject.Repository.Contracts;
using LoginProject.Librarys.Login;
using LoginProject.Librarys.Texto;
using LoginProject.Librarys.Email;
using LoginProject.Librarys.Lang;

namespace LoginProject.Controllers
{
    public class HomeController : Controller
    {
        private IUsuarioRepository _usuarioRepository;
        private LoginUsuario _loginUsuario;
        private KeyGenerator _keyGenerator;
        private GerenciarEmail _gerenciarEmail;
        private ISenhaRepository _senhaRepository;
        public HomeController(IUsuarioRepository usuarioRepository, LoginUsuario loginUsuario, KeyGenerator keyGenerator, GerenciarEmail gerenciarEmail, ISenhaRepository senhaRepository)
        {
            _usuarioRepository = usuarioRepository;
            _loginUsuario = loginUsuario;
            _keyGenerator = keyGenerator;
            _gerenciarEmail = gerenciarEmail;
            _senhaRepository = senhaRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([FromForm] Usuario usuario)
        {
            Usuario usuarioDB = _usuarioRepository.Login(usuario.Email);

            if(usuarioDB != null)
            {
                string senhaBanco = _keyGenerator.GetUniqueKey(8);
                SenhaKeyGenerator senha = new SenhaKeyGenerator() { Senha = senhaBanco };
                _senhaRepository.Cadastrar(senha);
                _gerenciarEmail.EnviarSenhaParaUsuarioPorEmail(usuario, senhaBanco);
                return RedirectToAction(nameof(Senha));
            }
            else
            {
                return View(nameof(Cadastrar));
            } 
        }
        [HttpGet]
        public IActionResult Senha()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Senha([FromForm] SenhaKeyGenerator senha)
        {
            SenhaKeyGenerator result = _senhaRepository.Procurar(senha.Senha);

            if (result != null)
            {
                return RedirectToAction(nameof(Painel));
            }
            else
            {
                ViewData["MSG_E"] = Mensagem.MSG_E004;
                return View();
            }
   
        }
        [HttpGet]
        public IActionResult Painel()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar([FromForm] Usuario usuario, string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                _usuarioRepository.Cadastrar(usuario);
                _loginUsuario.Login(usuario);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Cadastrar));
            }
        }


    }
}
