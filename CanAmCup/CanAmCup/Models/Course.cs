using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CanAmCup.Models
{
  public class Course
  {
    public int CourseId { get; set; }
    [Display(Name="Course Name")]
    public string Name { get; set; }
    public string Location { get; set; }
    [Display(Name = "Course Length")]
    public int CourseLength { get; set; }

    public virtual ICollection<Hole> Holes { get; set; }
  }
}
