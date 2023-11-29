using System.ComponentModel.DataAnnotations;

namespace SD
{
    public abstract class Building
    {
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public float Price { get; set; }
        public bool Sold { get; set; } = false;
        [Required]
        public float Dimensions { get; set; }
        [Required]
        public required Address Address { get; set; }
        public int Id { get => id; }
        public int id;
    }
    public class House : Building
    {
        [Required]
        public int Bedrooms { get; set; }
        [Required]
        public int Bathrooms { get; set; }
    }
    public class Apartment : Building
    {
        [Required]
        public int Bedrooms { get; set; }
        [Required]
        public int Bathrooms { get; set; }
        public string? ApartmentNum { get; set; }
    }
    public class Flat : Building
    {
        [Required]
        public bool LaundryIncluded { get; set; }
    }
    public class Kitnet : Building
    {
    }

}