using BancaBasica.Data;
using BancaBasica.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancaBasica.Controllers
{
    public class CuentasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CuentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            IEnumerable <Cuenta> listaCuentas = _context.cuenta;
            return View(listaCuentas);
        }

        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.Clientes = _context.cliente.ToList();
            return View();
        }

        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cuenta cuenta)
        {
            if (ModelState.IsValid) //validate all data anotations
            {
                _context.cuenta.Add(cuenta);
                _context.SaveChanges();

                TempData["mensaje"] = "La cuenta se ha creado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id  == null || Id == 0)
            {
                return NotFound();
            }

            //Obtener el cliente
            var cuenta = _context.cuenta.Find(Id);
            if (cuenta == null)
            {
                return NotFound();
            }

            ViewBag.Clientes = _context.cliente.ToList();
            return View(cuenta);
        }


        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cuenta cuenta)
        {
            if (ModelState.IsValid) //validate all data anotations
            {
                _context.cuenta.Update(cuenta);
                _context.SaveChanges();

                TempData["mensaje"] = "La cuenta se ha actualizado correctamente";
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

            //Obtener el cliente
            var cuenta = _context.cuenta.Find(Id);
            if (cuenta == null)
            {
                return NotFound();
            }


            return View(cuenta);
        }

        //Http Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCuenta(int? Id_Cuenta)
        {
            //Get client by ID
            var cuenta = _context.cuenta.Find(Id_Cuenta);

            if (cuenta == null)
            {
                return NotFound();
            }

            _context.cuenta.Remove(cuenta);
            _context.SaveChanges();

            TempData["mensaje"] = "La cuenta se ha eliminado correctamente";
            return RedirectToAction("Index");
        }
    }
}
