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
    public class IndexModel : PageModel
    {
        private readonly IGI_Web_953501_Smolyar.Data.ApplicationDbContext _context;

        public IndexModel(IGI_Web_953501_Smolyar.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Drink> Drink { get;set; }

        public async Task OnGetAsync()
        {
            Drink = await _context.Drinks
                .Include(d => d.Group).ToListAsync();
        }
    }
}
