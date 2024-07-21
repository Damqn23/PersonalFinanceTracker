using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Core.Interfaces;
using PersonalFinanceTracker.Core.Models;
using PersonalFinanceTracker.Infrastructure.Data.Models;

namespace PersonalFinanceTracker.Controllers
{
    public class FinancialRecordController : Controller
    {
        private readonly IFinancialRecordService _financialRecordService;

        public FinancialRecordController(IFinancialRecordService financialRecordService)
        {
            _financialRecordService = financialRecordService;
        }

        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
                var records = await _financialRecordService.GetAllRecordsAsync();

                // Create an instance of FinancialRecordIndexViewModel
                var viewModel = new FinancialRecordIndexViewModel
                {
                    Records = records.ToList()
                };

                return View(viewModel);
            
        }

        
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var record = await _financialRecordService.GetRecordByIdAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Amount,Date,Category,Type,UserId")] FinancialRecord record)
        {
            if (ModelState.IsValid)
            {
                await _financialRecordService.AddRecordAsync(record);
                return RedirectToAction(nameof(Index));
            }
            return View(record);
        }

        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var record = await _financialRecordService.GetRecordByIdAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Amount,Date,Category,Type,UserId")] FinancialRecord record)
        {
            if (id != record.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _financialRecordService.UpdateRecordAsync(record);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _financialRecordService.GetRecordByIdAsync(id) == null)
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(record);
        }

        
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _financialRecordService.GetRecordByIdAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _financialRecordService.DeleteRecordAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

