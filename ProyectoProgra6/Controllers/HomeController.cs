using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoProgra6.Models;

namespace ProyectoProgra6.Controllers
{
    public class HomeController : Controller
    {
        ProyectoProgra6Entities db = new ProyectoProgra6Entities();
        public ActionResult Index()
        {
            try
            {
                if (Session["usuario"] != null)
                {
                    var idUsuario = Session["usuario"];
                    var clientelog = db.sp_Seleccionar_Cliente((int)idUsuario).ToList();
                    Session["clientelog"] = clientelog;
                    ViewBag.clientelog = clientelog;
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = "Ocurrio un error : " + ex.Message;
                return View();
            }

        }

        public ActionResult LogOut()
        {
            Session["usuario"] = null;
            Session["clientelog"] = null;
            return RedirectToAction("Login", "Login");
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