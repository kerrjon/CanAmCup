using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CanAmCup.Models;

namespace CanAmCup.DAL
{
  public class SeedInitializer : CreateDatabaseIfNotExists<CanAmContext>
  //CreateDatabaseIfNotExists (default)
  //DropCreateDatabaseIfModelChanges
  //DropCreateDatabaseAlways
  {

    protected override void Seed(CanAmContext context)
    {

      var tournaments = new List<Tournament>
            {
            new Tournament{StartDateTime = DateTime.UtcNow, Winner = Country.CDN, Year = "2014"},
            new Tournament{StartDateTime = DateTime.UtcNow, Winner = Country.CDN, Year = "2015"},
            new Tournament{StartDateTime = DateTime.UtcNow, Winner = null, Year = "2016"}
            };
      foreach (var tournament in tournaments)
        context.Tournaments.Add(tournament);
      context.SaveChanges();

      var courses = new List<Course>
            {
            new Course{Location = "Mankato, MN", Name = "Terrace View Front 9"},
            new Course{Location = "Mankato, MN", Name = "Terrace View Back 9"},
            new Course{Location = "Mankato, MN", Name = "Terrace View 18"},
            new Course{Location = "Mankato, MN", Name = "North Links Front 9"},
            new Course{Location = "Mankato, MN", Name = "North Links Back 9"},
            new Course{Location = "Mankato, MN", Name = "North Links 18"}
            };
      courses.ForEach(s => context.Courses.Add(s));
      context.SaveChanges();


      var holes = new List<Hole>
            {
            new Hole{CourseId = courses.Single(s => s.Name == "Terrace View Front 9").CourseId , HoleNumber = 1},
            new Hole{CourseId = courses.Single(s => s.Name == "Terrace View Front 9").CourseId , HoleNumber = 2},
            new Hole{CourseId = courses.Single(s => s.Name == "Terrace View Front 9").CourseId , HoleNumber = 3},
            new Hole{CourseId = courses.Single(s => s.Name == "Terrace View Front 9").CourseId , HoleNumber = 4},
            new Hole{CourseId = courses.Single(s => s.Name == "Terrace View Front 9").CourseId , HoleNumber = 5},
            new Hole{CourseId = courses.Single(s => s.Name == "Terrace View Front 9").CourseId , HoleNumber = 6},
            new Hole{CourseId = courses.Single(s => s.Name == "Terrace View Front 9").CourseId , HoleNumber = 7},
            new Hole{CourseId = courses.Single(s => s.Name == "Terrace View Front 9").CourseId , HoleNumber = 8},
            new Hole{CourseId = courses.Single(s => s.Name == "Terrace View Front 9").CourseId , HoleNumber = 9},
      };
      holes.ForEach(s => context.Holes.Add(s));
      context.SaveChanges();


      // for weak entities
      //foreach (Enrollment e in enrollments)
      //{
      //  var enrollmentInDataBase = context.Enrollments.Where(
      //      s =>
      //           s.Student.ID == e.StudentID &&
      //           s.Course.CourseID == e.CourseID).SingleOrDefault();
      //  if (enrollmentInDataBase == null)
      //  {
      //    context.Enrollments.Add(e);
      //  }
      //}
      //context.SaveChanges();

    }
  }
}
