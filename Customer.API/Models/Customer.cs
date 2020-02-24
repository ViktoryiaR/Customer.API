namespace Customer.API.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }
    }
}
