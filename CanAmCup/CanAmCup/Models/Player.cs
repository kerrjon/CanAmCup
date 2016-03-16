using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CanAmCup.Models
{
  public class Player 
  {
    [Key]
    public int Id { get; set; }
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Please enter your last name.")]
    public string LastName { get; set; }
    [Display(Name = "E-Mail")]
    [DataType(DataType.EmailAddress)]
    [EmailAddress(ErrorMessage = "Not a valid email address.")]
    public string Email { get; set; }
    public string Phone { get; set; }
    public Country? Country { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    //public virtual ICollection<MatchPlayer> MatchPlayers { get;set; }
  }

  public enum Country
  {
    CDN, USA, None
  }
}