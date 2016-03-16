using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CanAmCup.Models
{
  public class Hole
  {
    public int HoleId { get; set; }
    public int HoleNumber { get; set; }
    public int CourseId { get; set; }

    public virtual Course Course { get; set; }
    //public virtual ICollection<Score> Scores { get; set; }
  }
}
