using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeightTracker.Data
{
    public class Measurement
    {
        [Required]
        public int MeasurementId { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Value { get; set; }
        [Column(TypeName = "date")]
        [Required]
        public DateTime TakenOn { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}