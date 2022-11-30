using ProyectoProgra6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoProgra6.Controllers
{
    public class LoginController : Controller
    {
        ProyectoProgra6Entities db = new ProyectoProgra6Entities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Usuario, string Password)
        {
            try
            {
                //var idUsuario = db.sp_Login(Usuario, Password);
                Nullable<int> myValue = db.sp_Login(Usuario, Password).FirstOrDefault();
                int idUsuario = myValue.Value;

                if (idUsuario != 0)
                {

                    Session["usuario"] = idUsuario;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["Mensaje"] = "Credenciales NO Validas";
                    return View();
                }

                //return View();
            }
            catch (Exception ex)
            {
                //return Content("Ocurrio un error : " + ex.Message);
                ViewData["Mensaje"] = "Ocurrio un error : " + ex.Message;
                return View();
            }

        }
    }
}