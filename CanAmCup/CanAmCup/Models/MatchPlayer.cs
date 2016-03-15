
namespace CanAmCup.Models
{
  public class MatchPlayer
  {
    public int MatchId { get; set; }
    public int PlayerId { get; set; }

    public virtual Player Players { get; set; }
    public virtual Match Matches { get; set; }
  }
}
