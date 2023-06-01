using LIBRERUMTEST.Datos;
using LIBRERUMTEST.Models;
using Microsoft.AspNetCore.Mvc;

namespace LIBRERUMTEST.Controllers
{

    public class VentaController : Controller
    {
        VentaDatos _VentaDatos = new VentaDatos();

        public IActionResult Listar()
        {
            //La vista mostrara una lista de _VentaDatos
            var oLista = _VentaDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Metodo solo devuelve la vista
            return View();
        }


        [HttpPost]
        public IActionResult Guardar(VentaModel oVenta)
        {
            ClienteModel cliente = new ClienteModel();
            ClienteDatos clienteDatos = new ClienteDatos();
            cliente = clienteDatos.Obtener(oVenta.ClienteModel.Cedula);
            if(cliente == null) 
                return BadRequest();

            oVenta.ClienteModel = cliente;
            //Metodo recibe el objeto para guardarlo en BD
            //if (!ModelState.IsValid)
            //    return View();

            var respuesta = _VentaDatos.Guardar(oVenta);

            if (respuesta)
                return RedirectToAction("Listar"); // me retorna al metodo donde tengo todos los contactos registrados
            else
                return View(); // retorna la misma vista para volver a guardar porque ha fallido
        }

        public IActionResult Editar(int CodigoVenta)
        {
            //Metodo solo devuelve la vista
            var ocontacto = _VentaDatos.Obtener(CodigoVenta);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Editar(VentaModel oVenta)
        {

            if (!ModelState.IsValid)
                return View();

            var respuesta = _VentaDatos.Editar(oVenta);

            if (respuesta)
                return RedirectToAction("Listar"); // me retorna al metodo donde tengo todos los contactos registrados
            else
                return View(); // retorna la misma vista para volver a guardar porque ha fallido
        }

        public IActionResult Eliminar(int CodigoVenta)
        {
            //Metodo solo devuelve la vista
            var ocontacto = _VentaDatos.Obtener(CodigoVenta);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Eliminar(VentaModel oVenta)
        {


            var respuesta = _VentaDatos.Eliminar(oVenta.CodigoVenta);

            if (respuesta)
                return RedirectToAction("Listar"); // me retorna al metodo donde tengo todos los contactos registrados
            else
                return View(); // retorna la misma vista para volver a guardar porque ha fallido
        }
    }
}
