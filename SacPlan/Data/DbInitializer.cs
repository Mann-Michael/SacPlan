using SacPlan.Models;
using System;
using System.Linq;

namespace SacPlan.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SacPlanContext context)
        {
            context.Database.EnsureCreated();

            // Look for any speakers.
            if (context.Speakers.Any())
            {
                return;   // DB has been seeded
            }

            var meetings = new Meeting[]
{
            new Meeting{MeetingDate=DateTime.Parse("2005-09-01"), Conductor="Person1", Presiding="Person2", Invocation="Person3", Benediction="Person4", OpeningHymn=1, SacramentHymn=1, IntermediateHymn=1,ClosingHymn=1},
            new Meeting{MeetingDate=DateTime.Parse("2005-09-01"), Conductor="Person4", Presiding="Person3", Invocation="Person2", Benediction="Person1", OpeningHymn=2, SacramentHymn=2, IntermediateHymn=2,ClosingHymn=2},
            new Meeting{MeetingDate=DateTime.Parse("2005-09-01"), Conductor="Person2", Presiding="Person3", Invocation="Person4", Benediction="Person1", OpeningHymn=3, SacramentHymn=3, IntermediateHymn=3,ClosingHymn=3},
            new Meeting{MeetingDate=DateTime.Parse("2005-09-01"), Conductor="Person1", Presiding="Person4", Invocation="Person3", Benediction="Person2", OpeningHymn=4, SacramentHymn=4, IntermediateHymn=4,ClosingHymn=4}
};
            foreach (Meeting m in meetings)
            {
                context.Meetings.Add(m);
            }
            context.SaveChanges();

            var speakers = new Speaker[]
            {
            new Speaker{FirstName="Carson",LastName="Alexander", Topic="Stuff 1" ,Order=1, MeetingID=1},
            new Speaker{FirstName="Meredith",LastName="Alonso", Topic="Stuff 2" ,Order=2, MeetingID=1},
            new Speaker{FirstName="Arturo",LastName="Anand", Topic="Stuff 3" ,Order=3, MeetingID=1},
            new Speaker{FirstName="Gytis",LastName="Barzdukas", Topic="Stuff 4" ,Order=1, MeetingID=2},
            new Speaker{FirstName="Yan",LastName="Li", Topic="Stuff 5" ,Order=2, MeetingID=2},
            new Speaker{FirstName="Peggy",LastName="Justice", Topic="Stuff 6" ,Order=3, MeetingID=3},
            new Speaker{FirstName="Laura",LastName="Norman", Topic="Stuff 7" ,Order=4, MeetingID=3},
            new Speaker{FirstName="Nino",LastName="Olivetto", Topic="Stuff 8" ,Order=4, MeetingID=4}
            };
            foreach (Speaker s in speakers)
            {
                context.Speakers.Add(s);
            }
            context.SaveChanges();
        }
    }
}