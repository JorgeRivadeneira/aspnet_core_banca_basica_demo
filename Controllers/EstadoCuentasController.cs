using BancaBasica.Data;
using BancaBasica.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancaBasica.Controllers
{
    public class EstadoCuentasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IEnumerable<Movimiento> lstMov;

        public EstadoCuentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            ViewBag.Clientes = _context.cliente.ToList();
            /*IEnumerable<Cuenta> listaCuentas = _context.cuenta;
            return View(listaCuentas);*/
            return View();
        }

        [HttpGet]
        public IActionResult Reporte()
        {
            List<Cuenta> lstCuentas;
            List<Movimiento> lstMovimientos;

            string id_cliente = HttpContext.Request.Query["Id_Cliente"].ToString();
            //Obtener los movimientos del cliente
            var cuentas = _context.cuenta.Where(x => x.Id_Cliente == int.Parse(id_cliente));
            lstCuentas = cuentas.ToList();

            var mov = _context.movimiento.Where(x => x.Id_Cuenta == lstCuentas[0].Id_Cuenta);
            lstMovimientos = mov.ToList();
            ViewBag.listaMovimientos = lstMovimientos;
            lstMov = lstMovimientos;

            IEnumerable<Movimiento> listaMovimientos = _context.movimiento;
            return View(lstMovimientos);
        }

        [HttpPost]
        public IActionResult Buscar(int Id_Cliente, DateTime FechaIni, DateTime FechaFin)
        {

            return Redirect("~/EstadoCuentas/Reporte?Id_Cliente=" + Id_Cliente.ToString() );
        }
    }
}
