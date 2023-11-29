using System.ComponentModel.DataAnnotations;

namespace SD
{
    public class Sale
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int SellerId { get; set; }
        [Required]
        public PaymentMethod PaymentMethod { get; set; }
        public int id;
        public int Id { get => id; }
    }


}