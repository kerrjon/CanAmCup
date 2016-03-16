using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CanAmCup.Models
{
  public class Tournament
  {
    public int TournamentId { get; set; }
    public string Year { get; set; }

    [Display(Name = "Start Date")]
    [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy  hh:mm tt}", ApplyFormatInEditMode = true)]
    public DateTime StartDateTime { get; set; }
    public Country? Champion { get; set; }

    public virtual ICollection<Match> Matches { get; set; }
  }
}
