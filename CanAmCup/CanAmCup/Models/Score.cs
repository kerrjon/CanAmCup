using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanAmCup.Models
{
  public class Score
  {
    [Key, Column(Order = 0)]
    public int MatchId { get; set; }
    [Key, Column(Order = 1)]
    public int HoleId { get; set; }
    public Country? HoleWinner { get; set; }

    public virtual Hole Holes { get; set; }
    public virtual Match Matches { get; set; }
  }
}

