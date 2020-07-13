using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomersTask.Models;

namespace CustomersTask.Controllers
{
    public class customerController : Controller
    {
        private readonly customerDbContext dbContext;

        public customerController(customerDbContext context)
        {
            dbContext = context;
        }

        // GET: customer
        public async Task<IActionResult> Index()
        {
            var customerDbContext = dbContext.Customers.Include(c => c.Government).Include(x => x.Government.Country);
            return View(await customerDbContext.ToListAsync());
        }

        // GET: customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await dbContext.Customers
                .Include(c => c.Government)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: customer/Create
        public IActionResult Create()
        {
            ViewData["countryId"] = new SelectList(dbContext.Countries, "countryId", "countryName");
            ViewData["governmentId"] = new SelectList(dbContext.Governments, "governmentId", "governmentName");
            return View();
        }

        [HttpPost]
        public IEnumerable<government> ReturnGovernmentById(int countryId) {
            var data = dbContext.Governments.Where(x => x.countryId == countryId).ToList();
            return data;
        }

        // POST: customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,phone,Gender,stateMarried,street,governmentId")] customer customer)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(customer);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["governmentId"] = new SelectList(dbContext.Governments, "governmentId", "governmentId", customer.governmentId);
            return View(customer);
        }

    }
}
