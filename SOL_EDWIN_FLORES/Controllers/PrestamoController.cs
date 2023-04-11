using SOL_EDWIN_FLORES.Clases;
using SOL_EDWIN_FLORES.Data;
using SOL_EDWIN_FLORES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SOL_EDWIN_FLORES.Controllers
{
    public class PrestamoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PrestamoController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var lista = new List<reportes>();
            using (var context = new ApplicationDbContext())
            {
                lista = (from prestamos in context.prestamos
                         join libros in context.libros on prestamos.id_libro equals libros.id
                         join usuarios in context.usuarios on prestamos.id_usuario equals usuarios.id
                         select new reportes
                         {
                             id_prestamo = prestamos.id,
                             id_libro = libros.id,
                             nombre_libro = libros.nombre,
                             fecha_prestamo = prestamos.fecha_prestamo,
                             dni_usuario = usuarios.dni,
                             nombre_usuario = usuarios.nombres,
                             apellido_usuario = usuarios.apellidos,
                             tipo_usuario = usuarios.tipo_usuario,
                             tipo_lectura = prestamos.tipo_lectura,
                             fecha_devolucion = prestamos.fecha_devolucion
                         }).ToList();
            }
            return View(lista);
        }

        public ActionResult CreatePrestamo()
        {

            try
            {

                var libros = _context.libros.ToList();
                var usuarios = _context.usuarios.ToList();

                ViewData["libros"] = new SelectList(libros.OrderBy(t => t.nombre), "id", "nombre");
                ViewData["usuarios"] = new SelectList(usuarios.OrderBy(t => t.nombres), "id", "nombres");

            }
            catch (Exception ex)
            {

                throw;
            }
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> CreatePrestamo(prestamos model)
        {
            //Validacion Cantidad Libros Por dia Máximo 3
            var fechaHoy = DateTime.Today;
            var usuario = model.id_usuario;
            var librosPrestadosHoy = _context.prestamos.Where(t => t.id_usuario.Equals(usuario) && t.fecha_prestamo.Equals(fechaHoy)).Count();

            //Validacion Usuario Sancionado
            var sancion = _context.usuarios.Where(t => t.id.Equals(usuario)).Select(t=>t.estado).FirstOrDefault();

            if (sancion == 0)
            {
                return Json(new { error = true, message = "El usuario ha sido sancionado" });
            }
            else if (librosPrestadosHoy >= 3) {
                
                return Json(new { error = true, message = "La cantidad máxima de libros prestados por día es 3" });
            }
            else
            {
                //Insert
                model.fecha_prestamo = DateTime.Now.Date;
                _context.prestamos.Add(model);
                await _context.SaveChangesAsync();
                return Json(new { error = false });
            }
        }


        [HttpPost]
        public async Task<ActionResult> Devolver(int id)
        {
            var prestamo = _context.prestamos.Where(t => t.id.Equals(id)).FirstOrDefault();
            prestamo.fecha_devolucion = DateTime.Today.Date;
            //_context.prestamos.AddOrUpdate(prestamo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult CreateDevolucion()
        {

            try
            {

                var libros = _context.libros.ToList();
                var usuarios = _context.usuarios.ToList();

                ViewData["libros"] = new SelectList(libros.OrderBy(t => t.nombre), "id", "nombre");
                ViewData["usuarios"] = new SelectList(usuarios.OrderBy(t => t.nombres), "id", "nombres");

            }
            catch (Exception ex)
            {

                throw;
            }
            return PartialView();
        }
    }
}