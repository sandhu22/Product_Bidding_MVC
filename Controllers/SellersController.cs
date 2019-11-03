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
    //Authorised seller controller.
    [Authorize]
    public class SellersController : Controller
    {
        private readonly Product_Bidding_MVCContext _context;

        public SellersController(Product_Bidding_MVCContext context)
        {
            _context = context;
        }

        // GET: Sellers
        //Gets all sellers using a linq query.
        public IActionResult Index()
        {
            return View((from seller in _context.Seller select seller).ToList());
        }

        // GET: Sellers/Details/5
        //Gets the seller details using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = _context.Seller
                .FirstOrDefault(m => m.Id == id);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        // GET: Sellers/Create
        //Gets the seller registration form.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sellers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Adds the seller to the databse.
        public IActionResult Create([Bind("Id,SellerName,ContactNumber")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seller);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(seller);
        }

        // GET: Sellers/Edit/5
        //Gets the seller for update using a linq query.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = (from sellers in _context.Seller
                          where sellers.Id == id
                          select sellers).FirstOrDefault();
            if (seller == null)
            {
                return NotFound();
            }
            return View(seller);
        }

        // POST: Sellers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the seller in the databse.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,SellerName,ContactNumber")] Seller seller)
        {
            if (id != seller.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seller);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellerExists(seller.Id))
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
            return View(seller);
        }

        // GET: Sellers/Delete/5
        //Gets the seller for delete using a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = _context.Seller
                .FirstOrDefault(m => m.Id == id);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        // POST: Sellers/Delete/5
        //Removes the seller . Uses  a linq query to select the seller.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var seller = (from sellers in _context.Seller
                          where sellers.Id == id
                          select sellers).FirstOrDefault();
            _context.Seller.Remove(seller);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the seller exists using a lamda query.
        private bool SellerExists(int id)
        {
            return _context.Seller.Any(e => e.Id == id);
        }
    }
}
