using Microsoft.AspNetCore.Mvc;
using CRUD_Clientes.Data;
using CRUD_Clientes.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Clientes.Controllers
{
    public class EmpleadoController : Controller
    {

        //Inyecciuon de dependencias
        private readonly DBContext _dbContext;

        public EmpleadoController(DBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]

        public async Task<IActionResult> Lista()
        {
            List<Empleado> lista = await _dbContext.Empleados.ToListAsync();
            return View(lista);
        }



        [HttpGet]

        public IActionResult Nuevo()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> Nuevo(Empleado empleado)
        {
            //Accedemos a la BD con el contexto y le pasamos el parametro para que lo agregue de forma asincrona
            await _dbContext.Empleados.AddAsync(empleado);
            //Guardamos los cambios realizados
            await _dbContext.SaveChangesAsync();
            //Nos redirigimos al metodo Lista
            return RedirectToAction(nameof(Lista));
        }


        [HttpGet]

        public async Task<IActionResult> Editar(int id)
        {
            Empleado empleado = await _dbContext.Empleados.FirstAsync(x=> x.IdEmpleado == id);
            return View(empleado);
        }


        [HttpPost]

        public async Task<IActionResult> Editar(Empleado empleado)
        {
            
            _dbContext.Empleados.Update(empleado);
            //Guardamos los cambios realizados
            await _dbContext.SaveChangesAsync();
            //Nos redirigimos al metodo Lista
            return RedirectToAction(nameof(Lista));
        }


        [HttpGet]

        public async Task<IActionResult> Eliminar(int id)
        {
            Empleado empleado = await _dbContext.Empleados.FirstAsync(x => x.IdEmpleado == id);
            _dbContext.Empleados.Remove(empleado);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

    }
}
