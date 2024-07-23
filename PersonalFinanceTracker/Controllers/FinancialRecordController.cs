using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Core.Interfaces;
using PersonalFinanceTracker.Core.Models;
using PersonalFinanceTracker.Infrastructure.Data.Models;

namespace PersonalFinanceTracker.Controllers
{
    [Authorize]
    
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
        public async Task<IActionResult> Create()
        {
            var viewModel = new FinancialRecordViewModel
            {
                Categories = await _financialRecordService.GetAllCategoriesAsync(),
                TransactionTypes = await _financialRecordService.GetAllTransactionTypesAsync()
            };
            return View(viewModel);
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FinancialRecordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var record = new FinancialRecord
                {
                    Description = viewModel.Description,
                    Amount = viewModel.Amount,
                    Date = viewModel.Date,
                    CategoryId = viewModel.CategoryId,
                    TransactionTypeId = viewModel.TransactionTypeId,
                    UserId = User.Identity.Name // Assuming User.Identity.Name returns the UserId
                };

                await _financialRecordService.AddRecordAsync(record);
                return RedirectToAction(nameof(Index));
            }

            viewModel.Categories = await _financialRecordService.GetAllCategoriesAsync();
            viewModel.TransactionTypes = await _financialRecordService.GetAllTransactionTypesAsync();

            return View(viewModel);
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

