using Microsoft.AspNetCore.Mvc;
using Web_24BM.Models;
using Web_24BM.Services;

namespace Web_24BM.Controllers
{
    public class ValidacionesController : Controller
    {

        private readonly ContactoService contactoService;
        public ValidacionesController(ContactoService contactoService)
        {
            this.contactoService = contactoService;
        }

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

            if (!ModelState.IsValid)
            {
                return View("Curriculum", model);
            }

            string mensaje = " ";
            
            mensaje = "Datos Correctos";
            
            this.contactoService.CrearContacto(model);
            
            TempData["Completado"] = "Datos guardados correctamente";

            return View("Curriculum",model) ;
            
        }

    }
}

