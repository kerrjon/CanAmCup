using System;
using System.Collections.Generic;


namespace CanAmCup.Models
{
  public class Match
  {
    public int MatchId { get; set; }
    public int TournamentId { get; set; }
    public Country? MatchWinner { get; set; }
    public DateTime StartDateTime { get; set; }
    public MatchType MatchType { get; set; }
    public string CourseName { get; set; }
    public double PointsAvailable { get; set; }
    public double TeamCdnPointsWon { get; set; }
    public double TeamUsaPointsWon { get; set; }

    public virtual ICollection<Score> Scores { get; set; }
    public virtual ICollection<MatchPlayer> MatchPlayers { get; set; }

    public virtual Tournament Tournament { get; set; }
  }

  public enum MatchType
  {
    BestBall, Scramble, Par3, Other
  }
}
