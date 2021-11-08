
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IGI_Web_953501_Smolyar.Entities
{
    public class DrinkGroup
    {
        [Key]
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public List<Drink> Drinks { get; set; }
    }
}
