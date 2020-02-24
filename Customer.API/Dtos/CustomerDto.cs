using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.API.Dtos
{
    [Table("Customer")]
    public class CustomerDto
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(150)]
        public string CustomerName { get; set; }

        [Required]
        [ForeignKey("Country")]
        public int CountryId { get; set; }
    }
}
