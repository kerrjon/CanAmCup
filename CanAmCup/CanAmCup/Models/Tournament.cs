using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CanAmCup.Models
{
  public class Tournament
  {
    public int TournamentId { get; set; }
    public string Year { get; set; }
    public DateTime StartDateTime { get; set; }
    public Country? Winner { get; set; }

    public virtual ICollection<Match> Matches { get; set; }
  }
}
