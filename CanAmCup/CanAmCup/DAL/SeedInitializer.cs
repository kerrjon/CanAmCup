using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CanAmCup.Models;

namespace CanAmCup.DAL
{
  public class SeedInitializer : DropCreateDatabaseIfModelChanges<CanAmContext>
  {
    protected override void Seed(CanAmContext context)
    {
      var players = new List<Player>
            {
              new Player{FirstName="Jon",LastName="Kerr", Email="kerrjon@yahoo.com", Phone = "612-356-7478", Country = Country.CDN, City = "Yorkton", State = "SK"},
              new Player{FirstName="Todd",LastName="Kelzenberg", Email="kelzenberg@gmail.com", Phone = "612-850-9893", Country = Country.USA, City = "Blaine", State = "MN"}
            };
      players.ForEach(s => context.Players.Add(s));
      context.SaveChanges();

      var course = new List<Course>
            {
            new Course{Location = "Mankato, MN", Name = "Terrace View"},
            new Course{Location = "Mankato, MN", Name = "North Links"}
            };
      course.ForEach(s => context.Courses.Add(s));
      context.SaveChanges();

      var matchSummary = new List<Tournament>
            {
            new Tournament{StartDateTime = DateTime.UtcNow, CdnScore = 3, UsaScore = 5.5, PointsAvailable = 3, Winner = Country.CDN, Year = "2014"},
            new Tournament{StartDateTime = DateTime.UtcNow, CdnScore = 4, UsaScore = 2, PointsAvailable = 1, Winner = Country.CDN, Year = "2015"},
            new Tournament{StartDateTime = DateTime.UtcNow, CdnScore = 0, UsaScore = 0, PointsAvailable = null, Winner = null, Year = "2016"}
            };
      matchSummary.ForEach(s => context.Tournaments.Add(s));
      context.SaveChanges();

      
    }
  }
}
