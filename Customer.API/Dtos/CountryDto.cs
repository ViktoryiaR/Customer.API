using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.API.Dtos
{
    [Table("Country")]
    public class CountryDto
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(150)]
        public string CountryName { get; set; }
    }
}
