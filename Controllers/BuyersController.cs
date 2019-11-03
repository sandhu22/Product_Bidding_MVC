using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Product_Bidding.BusinessLayer;
using Product_Bidding_MVC.Models;

namespace Product_Bidding_MVC.Controllers
{
    //Authorised buyer controller .
    [Authorize]
    public class BuyersController : Controller
    {
        private readonly Product_Bidding_MVCContext _context;

        public BuyersController(Product_Bidding_MVCContext context)
        {
            _context = context;
        }

        // GET: Buyers
        //Gets all buyers. using a linq query.
        public IActionResult Index()
        {
            return View((from buyer in _context.Buyer select buyer).ToList());
        }

        // GET: Buyers/Details/5
        //Gets the details of a buyer using a lamda query
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyer =  _context.Buyer
                .FirstOrDefault(m => m.Id == id);
            if (buyer == null)
            {
                return NotFound();
            }

            return View(buyer);
        }

        // GET: Buyers/Create
        //Gets the buyer registrtion form.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buyers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds a  buyer to the databse.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,BuyerName,BuyerAccountNumber")] Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buyer);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(buyer);
        }

        // GET: Buyers/Edit/5
        //Gets the buyer for update using a linq query
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyer = (from buyers in _context.Buyer
                         where buyers.Id == id
                         select buyers).FirstOrDefault();
            if (buyer == null)
            {
                return NotFound();
            }
            return View(buyer);
        }

        // POST: Buyers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the buyer 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,BuyerName,BuyerAccountNumber")] Buyer buyer)
        {
            if (id != buyer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buyer);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyerExists(buyer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(buyer);
        }

        // GET: Buyers/Delete/5
        //Gets the buyer for delete usig  a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyer = _context.Buyer
                .FirstOrDefault(m => m.Id == id);
            if (buyer == null)
            {
                return NotFound();
            }

            return View(buyer);
        }

        // POST: Buyers/Delete/5
        //Delete the buyer from databse uses a linq query to select the buyer.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var buyer = (from buyers in _context.Buyer
                         where buyers.Id == id
                         select buyers).FirstOrDefault();
            _context.Buyer.Remove(buyer);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks whether buyer exists using a lamda query.
        private bool BuyerExists(int id)
        {
            return _context.Buyer.Any(e => e.Id == id);
        }
    }
}
