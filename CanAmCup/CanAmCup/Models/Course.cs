using System.Collections.Generic;

namespace CanAmCup.Models
{
  public class Course
  {
    public int CourseId { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }

    public virtual ICollection<Hole> Holes { get; set; }
    public virtual ICollection<Match> Matches { get; set; }
  }
}
