using System.ComponentModel.DataAnnotations;

namespace Boncu_Nicole_Beatrice_Proiect.Models
{
    public class User
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        [StringLength(70)]
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Email { get; set; }
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau'0722.123.123' sau '0722 123 123'")]

        public string? Phone { get; set; }
    }
}
