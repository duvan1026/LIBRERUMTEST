using LIBRERUMTEST.Datos;
using LIBRERUMTEST.Models;
using Microsoft.AspNetCore.Mvc;

namespace LIBRERUMTEST.Controllers
{
    public class ClienteController : Controller
    {

        ClienteDatos _ClienteDatos = new ClienteDatos();

        public IActionResult Listar()
        {
            //La vista mostrara una lista de contactos
            var oLista = _ClienteDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ClienteModel oCliente)
        {
            //Metodo recibe el objeto para guardarlo en BD
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ClienteDatos.Guardar(oCliente);

            if (respuesta)
                return RedirectToAction("Listar"); // me retorna al metodo donde tengo todos los contactos registrados
            else
                return View(); // retorna la misma vista para volver a guardar porque ha fallido
        }
    }
}
