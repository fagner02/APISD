using System.ComponentModel.DataAnnotations;

namespace SD
{
    public class Customer
    {
        [Required]
        [MinLength(10)]
        public required string Name { get; set; }
        [Required]
        [MinLength(11)]
        public required string Cpf { get; set; }
        public int Id { get => id; }
        public int id;
        public List<PaymentMethod> PaymentMethods { get; set; } = new();

    }

    public enum PaymentMethod
    {
        CreditCard,
        Cash,
        Pix
    }

}