using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SnigdhaBeautyStudio.Data;
using SnigdhaBeautyStudio.Models;

namespace SnigdhaBeautyStudio.Controllers
{
    public class EnquiryViewModelsController : Controller
    {
        private SendMessageToServiceBus _SendMessageToServiceBus;
        
        public EnquiryViewModelsController(SendMessageToServiceBus SendMessageToServiceBus)
        {
            _SendMessageToServiceBus = SendMessageToServiceBus;
        }

        // GET: EnquiryViewModels
        public async Task<IActionResult> Index()
        {
            return View();
        }


        // GET: EnquiryViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnquiryViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Category,MobileNo,Name,EventDate,Quantity")] EnquiryViewModel enquiryViewModel)
        {
            if (ModelState.IsValid)
            {
               var result = await this._SendMessageToServiceBus.SendMessage(enquiryViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(enquiryViewModel);
        }

        //// GET: EnquiryViewModels/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var enquiryViewModel = await _context.EnquiryViewModel.FindAsync(id);
        //    if (enquiryViewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(enquiryViewModel);
        //}

        // POST: EnquiryViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Category,MobileNo,Name,EventDate,Quantity")] EnquiryViewModel enquiryViewModel)
        //{
        //    if (id != enquiryViewModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(enquiryViewModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EnquiryViewModelExists(enquiryViewModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(enquiryViewModel);
        //}

        // GET: EnquiryViewModels/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var enquiryViewModel = await _context.EnquiryViewModel
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (enquiryViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(enquiryViewModel);
        //}

        //// POST: EnquiryViewModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var enquiryViewModel = await _context.EnquiryViewModel.FindAsync(id);
        //    if (enquiryViewModel != null)
        //    {
        //        _context.EnquiryViewModel.Remove(enquiryViewModel);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool EnquiryViewModelExists(int id)
        //{
        //    return _context.EnquiryViewModel.Any(e => e.Id == id);
        //}
    }
}
