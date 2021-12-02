using BancaBasica.Data;
using BancaBasica.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancaBasica.Controllers
{
    public class MovimientosController : Controller
    {

        private readonly ApplicationDbContext _context;

        public MovimientosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Movimiento> listaMovimientos = _context.movimiento;
            return View(listaMovimientos);
        }

        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.Cuentas = _context.cuenta.ToList();
            return View();
        }

        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movimiento movimiento)
        {
            if (ModelState.IsValid) //validate all data anotations
            {
                var oMovimiento         = new Movimiento();
                oMovimiento.Id_Movimiento = movimiento.Id_Movimiento;
                oMovimiento.Valor       = movimiento.Valor;
                oMovimiento.Fecha       = System.DateTime.Now;
                oMovimiento.Id_Cuenta   = movimiento.Id_Cuenta;
                oMovimiento.Tipo        = movimiento.Tipo;

                _context.movimiento.Add(oMovimiento);
                _context.SaveChanges();

                TempData["mensaje"] = "La transaccion se ha creado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            //Obtener el cliente
            var movimiento = _context.movimiento.Find(Id);
            if (movimiento == null)
            {
                return NotFound();
            }

            ViewBag.Cuentas = _context.cuenta.ToList();
            return View(movimiento);
        }


        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movimiento movimiento)
        {
            if (ModelState.IsValid) //validate all data anotations
            {
                _context.movimiento.Update(movimiento);
                _context.SaveChanges();

                TempData["mensaje"] = "El movimiento se ha actualizado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var movimiento = _context.movimiento.Find(Id);
            if (movimiento == null)
            {
                return NotFound();
            }


            return View(movimiento);
        }

        //Http Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMovimiento(int? Id_Movimiento)
        {
            //Get client by ID
            var movimiento = _context.movimiento.Find(Id_Movimiento);

            if (movimiento == null)
            {
                return NotFound();
            }

            _context.movimiento.Remove(movimiento);
            _context.SaveChanges();

            TempData["mensaje"] = "El movimiento se ha eliminado correctamente";
            return RedirectToAction("Index");
        }
    }
}
