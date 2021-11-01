using IGI_Web_953501_Smolyar.Entities;
using IGI_Web_953501_Smolyar.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI_Web_953501_Smolyar.Controllers
{
    public class ProductController : Controller
    {
        List<Drink> _drinks;
        List<DrinkGroup> _DrinkGroups;
        int _pageSize;
        public ProductController()

        {
            _pageSize = 3;
            SetupData();
        }
        public IActionResult Index(int? group, int pageNo = 1)
        {
            ViewData["Groups"] = _DrinkGroups;
            ViewData["CurrentGroup"] = group ?? 0;
            return View(ListViewModel<Drink>.GetModel(_drinks.Where(d => !group.HasValue || d.GroupId == group.Value), pageNo,
            _pageSize));
        }

        /// <summary>
        /// Инициализация списков
        /// </summary>
        private void SetupData()
        {
            _DrinkGroups = new List<DrinkGroup>
            {
            new DrinkGroup {GroupId=1, Name="безалкогольные"},
            new DrinkGroup {GroupId=2, Name="алкогольные"},
            new DrinkGroup {GroupId=3, Name="горячие"},
            new DrinkGroup {GroupId=4, Name="холодные"},
            new DrinkGroup {GroupId=5, Name="газированные"},
            new DrinkGroup {GroupId=6, Name="негазированные"}
            };
            _drinks = new List<Drink>
            {
            new Drink {Id = 1, Name="Вода",
            Description="вода из под крана",
            Cost =2, GroupId=1, Image="Вода.jpg" },
            new Drink { Id = 2, Name="Пиво",
            Description="Пиво есть пиво что тут рассказывать",
            Cost =3, GroupId=2, Image="Пиво.jpg" },
            new Drink { Id = 3, Name="Кофе",
            Description="кофе без кофеина и сахара",
            Cost =3, GroupId=3, Image="Кофе.jpg" },
            new Drink { Id = 4, Name="Кофе",
            Description="кофе без кофеина и сахара, еще и холодный",
            Cost =5, GroupId=4, Image="Кофе.jpg" },
            new Drink { Id = 5, Name="RED COW",
            Description="RED COW помогает ведущим спортсменам,/nстудентам, представителям экстремальных\nпрофессий, а также во время длительных\nавтомобильных поездок",
            Cost =3, GroupId=5, Image="RedCow.jpg" },
            new Drink { Id = 5, Name="Чай",
            Description="Индийский чай",
            Cost =2, GroupId=6, Image="Чай.jpg" }

            };
        }
    }
}
