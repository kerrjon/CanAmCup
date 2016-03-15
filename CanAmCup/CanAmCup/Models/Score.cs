﻿
namespace CanAmCup.Models
{
  public class Score
  {
    public int ScoreId { get; set; }
    public int MatchId { get; set; }
    public int HoleId { get; set; }
    public Country? HoleWinner { get; set; }

    public virtual Hole Hole { get; set; }
    public virtual Match Match { get; set; }
  }
}
