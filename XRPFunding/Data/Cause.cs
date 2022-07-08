using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XRPFunding.Data
{
    public class Cause
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? Website { get; set; }

        [Required]
        public string? UserId { get; set; }

        [Required]
        public string? XRPLAddress { get; set; }

        [Required]
        public string? UrlPhoto { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public decimal FundGoal { get; set; }

        [Required]
        public decimal FundsNow { get; set; }
    }
}
