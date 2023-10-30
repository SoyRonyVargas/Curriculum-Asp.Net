using Microsoft.AspNetCore.Mvc;
using Web_24BM.Models;
using Web_24BM.Services;

namespace Web_24BM.Controllers
{
    public class ValidacionesController : Controller
    {

		[HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Curriculum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarFormulario(Curriculum model)
        {
            string mensaje = " ";
            
            mensaje = "Datos Correctos";

            MayateContext baseDeDatos = new MayateContext();

            Contacto nuevoContacto = new Contacto()
            {
                Nombre = model.Nombre,
                Apellidos = model.Apellidos,
                Email = model.Email
			};

            baseDeDatos.Contactos.Add(nuevoContacto);

            baseDeDatos.SaveChanges();

			return View("Curriculum",model) ;
            
        }

    }
}

