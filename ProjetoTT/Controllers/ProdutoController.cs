using Microsoft.AspNetCore.Mvc;
using ProjetoTT.Models;
using ProjetoTT.Repositorio;

namespace ProjetoTT.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoRepositorio _produtoRepositorio;
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _produtoRepositorio.AdicionarProduto(produto);
                return RedirectToAction("Cadastro");
            }
            return View(produto);
        }
    }
}
