using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace XRPFunding.Models
{
    public class CreateCauseFormModel
    {
        [Required]
        public string? Website { get; set; }

        [Required]
        [DisplayName("XRPL Address")]
        public string? XRPLAddress { get; set; }
        [Required]
        [DisplayName("Fund Goal")]
        public decimal FundGoal { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public DateTime? Deadline { get; set; }

        [Required]
        [DisplayName("Photo URL")]
        public string? UrlPhoto { get; set; }
    }
}
