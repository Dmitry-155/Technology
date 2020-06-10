using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using Technology.WebPortal.DAL;
using Technology.WebPortal.Models;
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

        [HttpGet]
        [Route("Home/Employees")]
        public IActionResult Employees()
        {
            ViewBag.Employees = 
                _context.Employees
                .ToList();

            return View();
        }

        [HttpGet]
        [Route("Home/EmployeeDetail/{id}")]
        public IActionResult EmployeeDetail(int id)
        {
            var employee = _context.Employees
                .AsNoTracking()
                .FirstOrDefault(m => m.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [Route("Home/EmployeeEdit/{id}")]
        public IActionResult EmployeeEdit(int id, [Bind("EmployeeId,Name,SurName,MidName,Phone,Address,Designation,Department")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction("Employees");
            }
            return View(employee);
        }

        [HttpGet]
        [Route("Home/Issues")]
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

        [HttpGet]
        [Route("Home/IssueDetail/{id}")]
        public IActionResult IssueDetail(int id)
        {
            var issue = _context.Issues
                .Include(i => i.Author)
                .Include(i => i.Executor)
                .Include(i => i.IssueCategory)
                .Include(i => i.Comments)
                .AsNoTracking()
                .FirstOrDefault(m => m.IssueID == id);

            var employees = _context.Employees.AsNoTracking();

            foreach (var comment in issue.Comments)
            {
                comment.Employer = employees.First(e => e.EmployeeId == comment.EmployerID);
            }

            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        [HttpPost]
        [Route("Home/IssueEdit/{id}")]
        public IActionResult IssueEdit(int id, [Bind("IssueID,Number,Description")] Issue issue)
        {
            if (id != issue.IssueID)
            {
                return NotFound();
            }

            var issueOrigin = _context.Issues
                .Include(i => i.Author)
                .Include(i => i.Executor)
                .Include(i => i.IssueCategory)
                .Include(i => i.Comments)
                .AsNoTracking()
                .FirstOrDefault(m => m.IssueID == id);

            issueOrigin.Number = issue.Number;
            issueOrigin.Description = issue.Description;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(issueOrigin);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction("Issues");
            }
            return View(issue);
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
