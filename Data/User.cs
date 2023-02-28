using System.ComponentModel.DataAnnotations;

namespace WeightTracker.Data;

public class User
{
    public int UserId { get; set; }
    [Required]
    [StringLength(40)]
    public string FirstName { get; set; }
    [Required]
    [StringLength(60)]
    public string LastName { get; set; }
    public virtual ICollection<Measurement> Measurements { get; set; }
}