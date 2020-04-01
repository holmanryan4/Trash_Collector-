using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Customer.Include("Address");
            
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .Include(c => c.Address)
                .Include(c => c.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
           
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id");

            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,AppUserId,Address,Account")] Customer customer)
        {

           

            if (ModelState.IsValid)
            {
                //customer.Account = new Account();
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.AppUserId = userId;
                
                _context.Add(customer);
             
                await _context.SaveChangesAsync();
                return RedirectToAction("CustomerHomepage", "Customers");
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", customer.AppUserId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", customer.AppUserId);
            ViewData["AddressId"] = new SelectList(_context.Set<Address>(), "Id", "Id", customer.AddressId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Customer customer)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = _context.Customer.Where(c => c.AppUserId == userId).Include("Address").Include("Account").FirstOrDefault();

            if (ModelState.IsValid)
            {


                var Dbcustomer = _context.Customer.Where(s => s.Id == customer.Id).FirstOrDefault();
                Dbcustomer.FirstName = customer.FirstName;
                Dbcustomer.LastName = customer.LastName;
                Dbcustomer.Address.StreetAddress = customer.Address.StreetAddress;
                Dbcustomer.Address.City = customer.Address.City;
                Dbcustomer.Address.State = customer.Address.State;
                Dbcustomer.Address.ZipCode = customer.Address.ZipCode;
                Dbcustomer.Account.StartDay = customer.Account.StartDay;
                Dbcustomer.Account.EndDay = customer.Account.EndDay;
                Dbcustomer.Account.PickupDay = customer.Account.PickupDay;

                Dbcustomer.Account.OneTimePickup = customer.Account.OneTimePickup;

                _context.SaveChanges();


                return RedirectToAction("Index", "Customers");
            }
            ViewData["AddressId"] = new SelectList(_context.Set<Address>(), "Id", "Id", customer.AddressId);
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", customer.AppUserId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .Include(c => c.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
        //GET Customer/Account
        public IActionResult Account()
        {

            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id");

            return View();
        }

        //POST: Customers/Account
       // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
       //  more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Account([Bind("Id,FirstName,LastName,AppUserId,Address,Account")]Account account)
        {



            if (ModelState.IsValid)
            {
                _context.Add(account);

                await _context.SaveChangesAsync();
                return RedirectToAction("CustomerHomepage", "Customers");
            }
            return View();
        }

        [HttpGet]
        public ActionResult CustomerHomepage()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = _context.Customer.Where(c=> c.AppUserId == userId).Include("Address").Include("Account").FirstOrDefault();
           
            return View(currentUser);
        }

        public IActionResult EditProfile(Customer customer)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = _context.Customer.Where(c => c.AppUserId == userId).Include("Address").Include("Account").FirstOrDefault();
            if (ModelState.IsValid)
            {
                

                var Dbcustomer = _context.Customer.Where(s => s.Id == customer.Id).FirstOrDefault();
                Dbcustomer.FirstName = customer.FirstName;
                Dbcustomer.LastName = customer.LastName;
                Dbcustomer.Address.StreetAddress = customer.Address.StreetAddress;
                Dbcustomer.Address.City = customer.Address.City;
                Dbcustomer.Address.State = customer.Address.State;
                Dbcustomer.Address.ZipCode = customer.Address.ZipCode;
                Dbcustomer.Account.EndDay = customer.Account.EndDay;
                Dbcustomer.Account.PickupDay = customer.Account.PickupDay;

                Dbcustomer.Account.OneTimePickup = customer.Account.OneTimePickup;

                _context.SaveChanges();


                return RedirectToAction("CustomerHomepage", "Customers");
            }
           
          
            return View(currentUser);
        }
       
        //    // POST: Customers/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> EditProfile(int id,  Customer customer)
        //    {
        //        if (id != customer.Id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(customer);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!CustomerExists(customer.Id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction("CustomerHomepage");
        //        }
        //        ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", customer.AppUserId);
        //        return View(customer);
        //    }

    }
}
