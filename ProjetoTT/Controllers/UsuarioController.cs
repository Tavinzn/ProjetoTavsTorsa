using Microsoft.AspNetCore.Mvc;
using ProjetoTT.Models;
using ProjetoTT.Repositorio;

namespace ProjetoEcommerce2A.Controllers
{
    public class UsuarioController : Controller
    {
        //construtor, ele inicializa o repositorio
        private readonly UsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var usuario = _usuarioRepositorio.ObterUsuario(email);
            if (usuario != null && usuario.Senha == senha)
            {
                // Autenticação bem-sucedida
                return RedirectToAction("Index", "Cliente");
            }
            ModelState.AddModelError("", "Email ou senha inválidos.");
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.AdicionarUsuario(usuario);
                return RedirectToAction("Login");
            }
            return View(usuario);
        }


    }
}
