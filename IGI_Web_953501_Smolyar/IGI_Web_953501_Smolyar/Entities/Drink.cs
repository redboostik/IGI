using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI_Web_953501_Smolyar.Entities
{
    public class Drink
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; } 
        public string Image { get; set; } 
        public int GroupId { get; set; }
        public DrinkGroup Group { get; set; }
    }
}
