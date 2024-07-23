using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Core.Interfaces;
using PersonalFinanceTracker.Core.Models;
using PersonalFinanceTracker.Infrastructure.Data;
using PersonalFinanceTracker.Infrastructure.Data.Models;
using System.Security.Claims;

namespace PersonalFinanceTracker.Controllers
{
    [Authorize]
    
    public class FinancialRecordController : Controller
    {
        private readonly IFinancialRecordService _financialRecordService;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<TransactionType> _transactionTypeRepository;
        private readonly FinanceDbContext _dbContext;

        public FinancialRecordController(
            IFinancialRecordService financialRecordService,
            IRepository<Category> categoryRepository,
            IRepository<TransactionType> transactionTypeRepository,
            FinanceDbContext dbContext)
        {
            _financialRecordService = financialRecordService;
            _categoryRepository = categoryRepository;
            _transactionTypeRepository = transactionTypeRepository;
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var records = await _financialRecordService.GetAllRecordsAsync();

            // Eager loading the related entities (Category and TransactionType)
            var recordsWithRelatedEntities = records.Select(fr => new FinancialRecord
            {
                Id = fr.Id,
                Description = fr.Description,
                Amount = fr.Amount,
                Date = fr.Date,
                Category = _dbContext.Categories.FirstOrDefault(c => c.Id == fr.CategoryId),
                TransactionType = _dbContext.TransactionTypes.FirstOrDefault(tt => tt.Id == fr.TransactionTypeId)
            }).ToList();

            var viewModel = new FinancialRecordIndexViewModel
            {
                Records = recordsWithRelatedEntities
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
            var viewModel = new FinancialRecordCreateViewModel
            {
                Categories = await GetCategoriesSelectListAsync(),
                TransactionTypes = await GetTransactionTypesSelectListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FinancialRecordCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var record = new FinancialRecord
                {
                    Description = model.Description,
                    Amount = model.Amount,
                    Date = model.Date,
                    CategoryId = model.CategoryId,
                    TransactionTypeId = model.TransactionTypeId,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };

                await _financialRecordService.AddRecordAsync(record);
                return RedirectToAction(nameof(Index));
            }

            // Log or inspect ModelState for debugging
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage); // Or use a logger
            }

            // If model state is invalid, re-populate the dropdown lists
            model.Categories = await GetCategoriesSelectListAsync();
            model.TransactionTypes = await GetTransactionTypesSelectListAsync();

            return View(model);
        }



        // Helper methods to get select lists
        private async Task<IEnumerable<SelectListItem>> GetCategoriesSelectListAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
        }

        private async Task<IEnumerable<SelectListItem>> GetTransactionTypesSelectListAsync()
        {
            var transactionTypes = await _transactionTypeRepository.GetAllAsync();
            return transactionTypes.Select(tt => new SelectListItem
            {
                Value = tt.Id.ToString(),
                Text = tt.Name
            }).ToList();
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

