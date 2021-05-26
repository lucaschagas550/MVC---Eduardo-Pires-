using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula1AspNetMVC.Controllers
{
    public class HomeController : Controller
    {
        //Como existe uma view com mesmo nome de Index não preciso, passar nenhum valor no retorno apenas chamar a view
        public ActionResult Index()
        {
            return View();
        }
        //Neste caso precisar ser passado o parametro por não ter o mesmo nome a view
        public ActionResult Teste()
        {
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}