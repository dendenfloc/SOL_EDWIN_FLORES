using SOL_EDWIN_FLORES.Data;
using SOL_EDWIN_FLORES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOL_EDWIN_FLORES.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var listaUsuarios = new List<usuarios>();
            using (var context = new ApplicationDbContext())
            {
                listaUsuarios = context.usuarios.ToList();
            }
            return RedirectToAction("Index", "Prestamo");
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