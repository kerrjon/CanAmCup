
using System.ComponentModel.DataAnnotations;

namespace CanAmCup.Models
{
  public class Score
  {
    public int ScoreId { get; set; }
    public int MatchId { get; set; }
    public int HoleId { get; set; }
    public Country? HoleWinner { get; set; }

    public virtual Hole Holes { get; set; }
    public virtual Match Matches { get; set; }
  }
}

