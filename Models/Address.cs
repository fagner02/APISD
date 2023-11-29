using System.ComponentModel.DataAnnotations;

namespace SD
{
    public class Address
    {
        [Required]
        public required string Street { get; set; }
        [Required]
        public required string Cep { get; set; }
        public string? Num { get; set; }
        public string? ReferencePoint { get; set; }
    }
}