using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MvcFechaCumples.Data;
using MvcFechaCumples.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFechaCumples.Controllers
{
    public class HomeController : Controller
    {
        private readonly MvcFechaCumplesContext _context;

        public HomeController(MvcFechaCumplesContext context)
        {
            _context = context;
        }

        // GET: Cumples
        public async Task<IActionResult> Index(string buscar)
        {
            var cumples = from m in _context.Cumple
                         select m;

            if (!String.IsNullOrEmpty(buscar))
            {
                cumples = cumples.Where(s => s.Nombre.Contains(buscar));
            }

            return View(await cumples.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
