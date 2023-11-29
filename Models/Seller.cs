using System.ComponentModel.DataAnnotations;

namespace SD
{
    public class Seller
    {
        [Required]
        public required string Name { get; set; }
        public int Id { get => id; }
        public int id;
    }
}