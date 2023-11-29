using System.ComponentModel.DataAnnotations;

namespace SD
{
    public class Customer
    {
        [Required]
        public required string Name { get; set; }
        [Required]
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