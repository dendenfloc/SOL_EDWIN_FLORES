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
            var lista = (from prestamos in _context.PRESTAMOS
                         join libros in _context.LIBROS on prestamos.ID_LIBRO equals libros.ID
                         join usuarios in _context.USUARIOS on prestamos.ID_USUARIO equals usuarios.ID
                         select new reportes
                         {
                             id_prestamo = prestamos.ID,
                             id_libro = libros.ID,
                             nombre_libro = libros.NOMBRE,
                             fecha_prestamo = prestamos.FECHA_PRESTAMO,
                             dni_usuario = usuarios.DNI,
                             nombre_usuario = usuarios.NOMBRE,
                             apellido_usuario = usuarios.APELLIDO,
                             tipo_usuario = usuarios.TIPO_USUARIO,
                             tipo_lectura = prestamos.TIPO_LECTURA,
                             fecha_devolucion = prestamos.FECHA_DEVOLUCION
                         }).ToList();
            return View(lista);
        }

        public ActionResult CreatePrestamo()
        {
            try
            {
                var libros = _context.LIBROS.ToList();
                var usuarios = _context.USUARIOS.ToList();
                var tipoPrestamo = new List<Combo>();
                tipoPrestamo.Add(new Combo { codigo = "Biblioteca", descripcion = "Biblioteca" });
                tipoPrestamo.Add(new Combo { codigo = "Retiro a casa", descripcion = "Retiro a casa" });
                ViewBag.tipoPrestamo = tipoPrestamo;
                ViewBag.libros = _context.LIBROS.ToList();
                ViewBag.usuarios = _context.USUARIOS.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> CreatePrestamo(PRESTAMOS model)
        {
            //Validacion Cantidad Libros Por dia Máximo 3
            var fechaHoy = DateTime.Today;
            var usuario = model.ID_USUARIO;
            var librosPrestadosHoy = _context.PRESTAMOS.Where(t => t.ID_USUARIO.Equals(usuario) && t.FECHA_PRESTAMO.Equals(fechaHoy)).Count();

            //Validacion Usuario Sancionado
            var sancion = _context.USUARIOS.Where(t => t.ID.Equals(usuario)).Select(t => t.ESTADO).FirstOrDefault();

            if (sancion == 0)
            {
                return Json(new { error = true, message = "El usuario ha sido sancionado" });
            }
            else if (librosPrestadosHoy >= 3)
            {

                return Json(new { error = true, message = "La cantidad máxima de libros prestados por día es 3" });
            }
            else
            {
                try
                {
                    //Insert
                    model.FECHA_PRESTAMO = DateTime.Now;
                    _context.PRESTAMOS.Add(model);
                    await _context.SaveChangesAsync();
                    return Json(new { error = false });
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        public async Task<ActionResult> Devolver(int id)
        {
            var prestamo = _context.PRESTAMOS.Where(t => t.ID.Equals(id)).FirstOrDefault();
            prestamo.FECHA_DEVOLUCION = DateTime.Now;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}