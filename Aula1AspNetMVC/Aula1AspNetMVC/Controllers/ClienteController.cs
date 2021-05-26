using Aula1AspNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula1AspNetMVC.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente

        //...cliente/teste
        public ActionResult Teste()
        {
            //propriedades automaticas, geralmente as informações vem do banco de dados
            var cliente = new Cliente()
            {
                Nome = "Asp",
                Sobrenome = "Net",
                DataCadastro = DateTime.Now,
                Id = 1
            };

            //ViewBag.Cliente = cliente;
            ViewData["Cliente"] = cliente;

            return View("Index", cliente); // passa o objeto por parametro para a view, posso indicar qual view estou chamando mesmo com actionresult diferente
        }

        //cada actionresulta teoricamente tem uma view
        public ActionResult Lista()
        {
            var listaClientes = new List<Cliente>()
            {
                new Cliente(){Nome ="Joao",Sobrenome="Pedro",DataCadastro=DateTime.Now,Id=1},

                new Cliente(){Nome ="Fulano",Sobrenome="Beltrano",DataCadastro=DateTime.Now,Id=2},
            };

            return View(listaClientes);
        }

        public ActionResult Pesquisa(int? id, string nome /*string id*/)
        {
            var listaClientes = new List<Cliente>()
            {
                new Cliente(){Nome ="Joao",Sobrenome="Pedro",DataCadastro=DateTime.Now,Id=1},
                new Cliente(){Nome ="Fulano",Sobrenome="Beltrano",DataCadastro=DateTime.Now,Id=2},
                new Cliente(){Nome ="Eduardo",Sobrenome="Pires",DataCadastro=DateTime.Now,Id=3},
                new Cliente(){Nome ="Aluno",Sobrenome="Pires",DataCadastro=DateTime.Now,Id=4},
                new Cliente(){Nome ="Lucas",Sobrenome="Andrade",DataCadastro=DateTime.Now,Id=5},
            };

            //var cliente = listaClientes.Where(c => c.Nome.ToLower() == id.ToLower()).ToList();

            var cliente = listaClientes.Where(c => c.Id == id && c.Nome.ToLower() == nome.ToLower()).ToList();

            if (!cliente.Any())
            {
                TempData["erro"] = "Nenhum cliente selecionado";
                return RedirectToAction("ErroPesquisa"); // redireciona a ação para a ErroPesquisa e ela chamara a view de erro
            }

            return View("Lista", cliente);
        }

        public ActionResult ErroPesquisa()
        {
            return View("Error");
        }
    }
}