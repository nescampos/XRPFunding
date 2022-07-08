using System.ComponentModel.DataAnnotations;

namespace XRPFunding.Models
{
    public class DonateFormModel
    {
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string? XRPLAddress { get; set; }

        [Required]
        public int Id { get; set; }

    }
}
