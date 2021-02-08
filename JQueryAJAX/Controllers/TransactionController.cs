using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JQueryAJAX.Models;

namespace JQueryAJAX.Controllers
{
    public class TransactionController : Controller
    {
        private readonly TransactionDbContext _context;

        public TransactionController(TransactionDbContext context)
        {
            _context = context;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transations.ToListAsync());
        }

        // GET: Transaction/AddOrEdit
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if(id == 0) { 
                return View( new TransationModel());
            }
            else
            {
                var transationModel = await _context.Transations.FindAsync(id);
                if (transationModel == null)
                {
                    return NotFound();
                }
                return View(transationModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public async Task<IActionResult> AddOrEdit(int id, [Bind("TransitionId,AccountNumber,BeneficiaryName,BankName,SwiftCode,Amount,Date")] TransationModel transationModel)
        {
      

            if (ModelState.IsValid)
            {
                if(id == 0) 
                {
                    transationModel.Date = DateTime.Now;
                    _context.Add(transationModel);
                    await _context.SaveChangesAsync();
                }
                else 
                {
                    try
                    {
                        _context.Update(transationModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TransationModelExists(transationModel.TransitionId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Transations.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", transationModel) });
        }

 
        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transationModel = await _context.Transations.FindAsync(id);
            _context.Transations.Remove(transationModel);
            await _context.SaveChangesAsync();
            return Json(new {html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Transations.ToList()) });
        }

        private bool TransationModelExists(int id)
        {
            return _context.Transations.Any(e => e.TransitionId == id);
        }
    }
}
