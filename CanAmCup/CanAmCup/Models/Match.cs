using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CanAmCup.Models
{
  public class Match
  {
    public int MatchId { get; set; }
    public int TournamentId { get; set; }
    public Country? MatchWinner { get; set; }

    [Display(Name = "Start Time")]
    [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy  hh:mm tt}", ApplyFormatInEditMode = true)]
    public DateTime StartDateTime { get; set; }
    [Display(Name = "Match Type")]
    public MatchType MatchType { get; set; }
    [Display(Name = "Course")]
    public string CourseName { get; set; }
    [Display(Name = "Points Available")]
    public double PointsAvailable { get; set; }
    [Display(Name = "Team Canada Points")]
    public double TeamCdnPointsWon { get; set; }
    [Display(Name = "Team USA Points")]
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
