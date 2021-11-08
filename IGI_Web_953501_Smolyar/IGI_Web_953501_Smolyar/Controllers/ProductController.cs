using IGI_Web_953501_Smolyar.Entities;
using IGI_Web_953501_Smolyar.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  IGI_Web_953501_Smolyar.Extensions;
using IGI_Web_953501_Smolyar.Data;

namespace IGI_Web_953501_Smolyar.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;
        int _pageSize;
        public ProductController(ApplicationDbContext context)

        {
            _pageSize = 3;
            _context = context;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            ViewData["Groups"] = _context.DrinkGroups;
            ViewData["CurrentGroup"] = group ?? 0;
            var model = ListViewModel<Drink>.GetModel(_context.Drinks.Where(d => !group.HasValue || d.GroupId == group.Value), pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }


    }
}
