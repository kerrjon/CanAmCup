
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanAmCup.Models
{
  public class MatchPlayer
  {
    [Key, Column(Order = 0)]
    public int MatchId { get; set; }
    [Key, Column(Order = 1)]
    public int PlayerId { get; set; }

    public virtual Player Players { get; set; }
    public virtual Match Matches { get; set; }
  }
}
