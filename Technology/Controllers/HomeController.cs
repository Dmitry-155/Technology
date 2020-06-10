﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using Technology.WebPortal.DAL;
using WebApplication444.Models;

namespace WebApplication444.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly EmployeeDbContext _context;

        public HomeController(ILogger<HomeController> logger, EmployeeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Employees()
        {
            ViewBag.Employees = 
                _context.Employees
                .ToList();

            return View();
        }

        public IActionResult Issues()
        {
            ViewBag.Issues = 
                _context.Issues
                .Include(i => i.Author)
                .Include(i => i.Executor)
                .Include(i => i.IssueCategory)
                .Include(i => i.Comments)
                .ToList();

            return View();
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
