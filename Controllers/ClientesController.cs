using BancaBasica.Data;
using BancaBasica.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancaBasica.Controllers
{
    
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Http Get Index
        public IActionResult Index()
        {
            IEnumerable<Cliente> listaClientes = _context.cliente;
            return View(listaClientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid) //validate all data anotations
            {
                _context.cliente.Add(cliente);
                _context.SaveChanges();

                TempData["mensaje"] = "El Cliente se ha creado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }

            //Obtener el cliente
            var cliente = _context.cliente.Find(Id);
            if(cliente == null)
            {
                return NotFound();
            }


            return View(cliente);
        }


        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid) //validate all data anotations
            {
                _context.cliente.Update(cliente);
                _context.SaveChanges();

                TempData["mensaje"] = "El Cliente se ha actualizado correctamente";
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
            var cliente = _context.cliente.Find(Id);
            if (cliente == null)
            {
                return NotFound();
            }


            return View(cliente);
        }

        //Http Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCliente(int? Id)
        {
            //Get client by ID
            var cliente = _context.cliente.Find(Id);

            if(cliente == null)
            {
                return NotFound();
            }

            _context.cliente.Remove(cliente);
            _context.SaveChanges();

            TempData["mensaje"] = "El Cliente se ha eliminado correctamente";
            return RedirectToAction("Index");
        }
    }
}
