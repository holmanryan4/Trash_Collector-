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
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Newtonsoft.Json;

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
        public async Task<IActionResult> Index(string searchString)
        {
            var user = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userCustomer = _context.Customer.Where(s => s.AppUserId == user).FirstOrDefault();
            var applicationDbContext = _context.Customer.Include("Address").Include("Account");

           
            var customerday = from m in _context.Customer
                              .Where(c => c.AccountId == userCustomer.Id)
                              select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                customerday = customerday.Where(s => s.Account.PickupDay.Contains(searchString));

                return View(await customerday.ToListAsync());
            }
            return View(await applicationDbContext.ToListAsync());

        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
           
            var customer = await _context.Customer
                .Include(c => c.Address)
                .Include(c => c.AppUser)
                .Include(c => c.Account)
                .FirstOrDefaultAsync(m => m.Id == id);

           
            var mapUser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userMap = _context.Customer.Include(c => c.Address).Where(c => c.AppUserId == mapUser)
                .Select(c => c.Address).SingleOrDefault();
            ViewBag.mymap = "https://maps.googleapis.com/maps/api/js?key=" + APIs.Keys.googleKey + "&callback=initMap";
            ViewBag.CustomerLat = customer.Address.Lat;
            ViewBag.CustomerLng = customer.Address.Lng;
            return View("Details", customer);
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
        public async Task<IActionResult> Create( Customer customer)
        {

           

            if (ModelState.IsValid)
            {
                //customer.Account = new Account();
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.AppUserId = userId;
                
                _context.Add(customer);
             
                await _context.SaveChangesAsync();

                var user = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userCustomer = _context.Customer.Where(s => s.AppUserId == user).FirstOrDefault();
                HttpClient client = new HttpClient();
                if (userCustomer.Address.Lat == null || userCustomer.Address.Lng == null)
                {
                    string location = userCustomer.Address.StreetAddress + "+" + userCustomer.Address.City + "+" + userCustomer.Address.State + "+" + userCustomer.Address.ZipCode;
                    string url = "https://maps.googleapis.com/maps/api/geocode/json?address=" + location + "&key=" + APIs.Keys.googleKey;
                    HttpResponseMessage response = await client.GetAsync(url);
                    string answer = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        GeoCode GeoResult = JsonConvert.DeserializeObject<GeoCode>(answer);
                        var lat = GeoResult.results[0].geometry.location.lat;
                        var lng = GeoResult.results[0].geometry.location.lng;
                        userCustomer.Address.Lat = lat;
                        userCustomer.Address.Lng = lng;
                        _context.Update(userCustomer.Address);
                    }
                    await _context.SaveChangesAsync();
                }


                return RedirectToAction("CustomerHomepage", "Customers");
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", customer.AppUserId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            

            var customer = await _context.Customer.FindAsync(id);
            
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
            return View();
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
                .Include(c => c.Account)
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
