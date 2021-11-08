using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IGI_Web_953501_Smolyar.Data;
using IGI_Web_953501_Smolyar.Entities;

namespace IGI_Web_953501_Smolyar.Areas.Admin.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IGI_Web_953501_Smolyar.Data.ApplicationDbContext _context;

        public DeleteModel(IGI_Web_953501_Smolyar.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Drink Drink { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Drink = await _context.Drinks
                .Include(d => d.Group).FirstOrDefaultAsync(m => m.Id == id);

            if (Drink == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Drink = await _context.Drinks.FindAsync(id);

            if (Drink != null)
            {
                _context.Drinks.Remove(Drink);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
