using System.Collections.Generic;

namespace CanAmCup.Models
{
  public class Hole
  {
    public int HoleId { get; set; }
    public int Number { get; set; }
    public int CourseId { get; set; }

    public virtual Course Course { get; set; }
    public virtual ICollection<Score> Scores { get; set; }
  }
}
