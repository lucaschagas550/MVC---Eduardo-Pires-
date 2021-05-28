using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aula1AspNetMVC.Context;
using Aula1AspNetMVC.Models;

namespace Aula1AspNetMVC.Controllers
{
    public class ClientesController : Controller
    {
        private Aula1Context db = new Aula1Context(); // instancia do banco de dados
        //teste de tag helpers
        public ActionResult Teste()
        {
            ViewBag.Ola = "<h2>OLa</h2>";

            ViewBag.Id = new SelectList(db.Cliente.ToList(),"Id","Nome",2);// Procuro pelo id e mostro o nome, o valor 2 deixa pre-selecionado, o nome da viewbag.id facilita a criação da lista

            return View(db.Cliente.ToList());
        }

        public ActionResult Teste1()
        {
            return Json(db.Cliente.ToList(), JsonRequestBehavior.AllowGet);
            //new HttpUnauthorizedResult(); 
            //HttpNotFound();
            //JavaScript("<script>alert('olá');</script>"); //utilizar javascript html.raw na view para recuperar a função correta
            //Content("Olá :)");
            //Json(db.Cliente.ToList(), JsonRequestBehavior.AllowGet);
            //PartialView("_Saudacao");
        }

        [OutputCache(Duration =30, VaryByParam = "id")]
        // Faz um request a cada 30 segundos para atualizar as informações, VaryByParam siginifica que é um cache para cada parametro novo que for recebido
        // posso ter varias parametros, se colocar "*" ele varia para todos parametros 
        public ContentResult Teste2(int id)
        {

            return Content(DateTime.Now.ToString());
        }


        // GET: Clientes
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Cliente.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        // devolve os dados de criação do cliente com os dados realizados em create
        [HttpPost] //actionselector somente trabalhara com post
        [ValidateAntiForgeryToken] // Previne ataques de cross site request forgeries, seria forja um request finge o local da onde vem a informação
        public ActionResult Create(Cliente cliente) //[Bind(Include = "Id,Nome,Sobrenome,Email")]  permite eu escolher os dados que eu quero receber
        {
            if (ModelState.IsValid) // valida os campos e somente depois disso adiciona no banco de dados
            {
                if (!cliente.Email.Contains(".br"))
                {
                    ModelState.AddModelError(String.Empty,"E-mail não pode ser internacional"); // caso der erro volta os dados do cliente para a view
                        return View(cliente);
                }

                cliente.DataCadastro = DateTime.Now;
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Bind permite uma maior segurança, se possivel deve ser utilizado
        //Ele evita que seja manipulado o html da pagina e injetem informações nele e seja feito um post
        public ActionResult Edit([Bind(Include = "Id,Nome,Sobrenome,DataCadastro")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
