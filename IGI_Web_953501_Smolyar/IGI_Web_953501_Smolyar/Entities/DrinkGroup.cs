using System.Collections.Generic;

namespace IGI_Web_953501_Smolyar.Entities
{
    public class DrinkGroup
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public List<Drink> Drinks { get; set; }
    }
}
