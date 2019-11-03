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
    //Bids controller with authorization
    [Authorize]
    public class BidsController : Controller
    {
        private readonly Product_Bidding_MVCContext _context;

        public BidsController(Product_Bidding_MVCContext context)
        {
            _context = context;
        }

        // Get All Bids using a lamda query
        public IActionResult Index()
        {
            var product_Bidding_MVCContext = _context.Bid.Include(b => b.Buyer).Include(b => b.Product).Include(b => b.Seller);
            return View(product_Bidding_MVCContext.ToList());
        }

        // Get details of bid using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid =  _context.Bid
                .Include(b => b.Buyer)
                .Include(b => b.Product)
                .Include(b => b.Seller)
                .FirstOrDefault(m => m.Id == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        // Get The bid creation form.
        public IActionResult Create()
        {
            ViewData["BuyerId"] = new SelectList(_context.Set<Buyer>(), "Id", "BuyerRegistrationId");
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "ProductRegistrationId");
            ViewData["SellerId"] = new SelectList(_context.Set<Seller>(), "Id", "SellerRegistrationNumber");
            return View();
        }

        // POST: Bids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds a bid to the database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,ProductId,BuyerId,SellerId,BidPrice")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bid);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuyerId"] = new SelectList(_context.Set<Buyer>(), "Id", "BuyerAccountNumber", bid.BuyerId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "ProductName", bid.ProductId);
            ViewData["SellerId"] = new SelectList(_context.Set<Seller>(), "Id", "SellerName", bid.SellerId);
            return View(bid);
        }

        // GET: Bids/Edit/5
        //Gets the bid for edit using a linq query.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = (from bids in _context.Bid
                       where bids.Id == id
                       select bids).FirstOrDefault();
            if (bid == null)
            {
                return NotFound();
            }
            ViewData["BuyerId"] = new SelectList(_context.Set<Buyer>(), "Id", "BuyerAccountNumber", bid.BuyerId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "ProductName", bid.ProductId);
            ViewData["SellerId"] = new SelectList(_context.Set<Seller>(), "Id", "SellerName", bid.SellerId);
            return View(bid);
        }

        // POST: Bids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the bid.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,ProductId,BuyerId,SellerId,BidPrice")] Bid bid)
        {
            if (id != bid.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bid);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidExists(bid.Id))
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
            ViewData["BuyerId"] = new SelectList(_context.Set<Buyer>(), "Id", "BuyerAccountNumber", bid.BuyerId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "ProductName", bid.ProductId);
            ViewData["SellerId"] = new SelectList(_context.Set<Seller>(), "Id", "SellerName", bid.SellerId);
            return View(bid);
        }

        // GET: Bids/Delete/5
        //Gets a bid for delete using  a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid =  _context.Bid
                .Include(b => b.Buyer)
                .Include(b => b.Product)
                .Include(b => b.Seller)
                .FirstOrDefault(m => m.Id == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        // POST: Bids/Delete/5
        //Deletes a bid from databse uses a linq query to select the record.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var bid = (from bids in _context.Bid
                       where bids.Id == id
                       select bids).FirstOrDefault();
            _context.Bid.Remove(bid);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks whether the bid exists using a lamda query.
        private bool BidExists(int id)
        {
            return _context.Bid.Any(e => e.Id == id);
        }
    }
}
