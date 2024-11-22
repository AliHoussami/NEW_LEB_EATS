using System.ComponentModel.DataAnnotations;

namespace TEST2.Models
{
    public class RestaurantModel
    {
        [Key]
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set;}
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set;}  
        public string Address { get; set;}
        public string City { get; set;}
        public string PostalCode { get; set;}
        public string OpeningHours { get; set;}
        public decimal Rating { get; set; }
    }
}
