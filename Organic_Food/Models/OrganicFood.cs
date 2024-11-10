using System.ComponentModel.DataAnnotations;

namespace Organic_Food.Models
{
    public class OrganicFood
    {
        public int ID { get; set; }
        public string  Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        
        public int Price { get; set; }
        public string photo { get; set; }
    }
}
