using System;
using System.Collections.Generic;

namespace CanAmCup.Models
{
  public class Tournament
  {
    public int TournamentId { get; set; }
    public string Year { get; set; }
    public DateTime StartDateTime { get; set; }
    public double UsaScore { get; set; }
    public double CdnScore { get; set; }
    public double? PointsAvailable { get; set; }
    public Country? Winner { get; set; }

    public virtual ICollection<Match> Matches { get; set; }
  }
}
