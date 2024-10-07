using DsiVendas.Models;
using Microsoft.AspNetCore.Mvc;

namespace DsiVendas.Controllers
{
    public class FornecedoresController(ApplicationDbContext context) : Controller
    {
        public IActionResult Index()
        {
            var listaFornecedor = context.Fornecedores.ToList();
            return View(listaFornecedor);
        }

        public List<Fornecedor> Api()
        {
            var listaFornecedor = context.Fornecedores.ToList();
            return listaFornecedor;
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Fornecedor fornecedor)
        {
            context.Fornecedores.Add(fornecedor);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var fornecedor = context.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        [HttpPost]
        public IActionResult Editar(Fornecedor fornecedor)
        {
            var fornecedorExistente = context.Fornecedores.Find(fornecedor.Id);
            if (fornecedorExistente == null)
            {
                return NotFound();
            }
            fornecedorExistente.Nome = fornecedor.Nome;
            fornecedorExistente.Telefone = fornecedor.Telefone;
            fornecedorExistente.Cidade = fornecedor.Cidade;
            context.Fornecedores.Update(fornecedorExistente);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
