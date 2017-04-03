using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithWebsite.Data;

namespace ZenithWebsite.Models
{
    public class ActivityEventSeedData
    {
        public static void Initialize(ApplicationDbContext db)
        {
            //add activities
            if (!db.Activity.Any())
            {
                db.Activity.Add(new Activity { ActivityDescription = "Ski Tournament", CreationDate = new DateTime(2017, 2, 9) });
                db.Activity.Add(new Activity { ActivityDescription = "Triathalon", CreationDate = new DateTime(2017, 2, 10) });
                db.Activity.Add(new Activity { ActivityDescription = "Snowboard Tournament", CreationDate = new DateTime(2017, 2, 10) });
                db.Activity.Add(new Activity { ActivityDescription = "Biking Race", CreationDate = new DateTime(2017, 2, 11) });
                db.Activity.Add(new Activity { ActivityDescription = "Basketball Game", CreationDate = new DateTime(2017, 2, 11) });
                db.Activity.Add(new Activity { ActivityDescription = "Soccer Game", CreationDate = new DateTime(2017, 2, 11) });
                db.Activity.Add(new Activity { ActivityDescription = "Golf Tournament", CreationDate = new DateTime(2017, 2, 12) });
                db.Activity.Add(new Activity { ActivityDescription = "Swimming Race", CreationDate = new DateTime(2017, 2, 12) });
                db.Activity.Add(new Activity { ActivityDescription = "Doubles Tennis Game", CreationDate = new DateTime(2017, 2, 12) });
                db.Activity.Add(new Activity { ActivityDescription = "Family Bowling", CreationDate = new DateTime(2017, 2, 13) });
                db.Activity.Add(new Activity { ActivityDescription = "Rock Concert", CreationDate = new DateTime(2017, 2, 13) });
                db.Activity.Add(new Activity { ActivityDescription = "Potluck", CreationDate = new DateTime(2017, 2, 13) });

                db.SaveChanges();
            }

            //add events
            if (!db.Event.Any())
            {
                db.Event.Add(new Event
                {
                    DateFrom = new DateTime(2017, 4, 5, 9, 0, 0),
                    DateTo = new DateTime(2017, 4, 5, 12, 0, 0),
                    EventMadeBy = "a",
                    IsActive = true,
                    ActivityId = db.Activity.FirstOrDefault(c => c.ActivityDescription == "Ski Tournament").ActivityId,
                    CreationDate = new DateTime(2017, 4, 3, 0, 0, 1)
                });
                db.Event.Add(new Event
                {
                    DateFrom = new DateTime(2017, 4, 6, 14, 0, 0),
                    DateTo = new DateTime(2017, 4, 6, 17, 0, 0),
                    EventMadeBy = "a",
                    IsActive = true,
                    ActivityId = db.Activity.FirstOrDefault(c => c.ActivityDescription == "Triathalon").ActivityId,
                    CreationDate = new DateTime(2017, 3, 9, 0, 0, 2)
                });
                db.Event.Add(new Event
                {
                    DateFrom = new DateTime(2017, 4, 7, 9, 0, 0),
                    DateTo = new DateTime(2017, 4, 7, 12, 0, 0),
                    EventMadeBy = "a",
                    IsActive = true,
                    ActivityId = db.Activity.FirstOrDefault(c => c.ActivityDescription == "Biking Race").ActivityId,
                    CreationDate = new DateTime(2017, 3, 9, 0, 0, 3)
                });
                db.Event.Add(new Event
                {
                    DateFrom = new DateTime(2017, 4, 8, 14, 0, 0),
                    DateTo = new DateTime(2017, 4, 8, 17, 0, 0),
                    EventMadeBy = "Jim",
                    IsActive = true,
                    ActivityId = db.Activity.FirstOrDefault(c => c.ActivityDescription == "Basketball Game").ActivityId,
                    CreationDate = new DateTime(2017, 3, 10, 0, 0, 4)
                });
                db.Event.Add(new Event
                {
                    DateFrom = new DateTime(2017, 4, 10, 9, 0, 0),
                    DateTo = new DateTime(2017, 4, 10, 12, 0, 0),
                    EventMadeBy = "Sara",
                    IsActive = true,
                    ActivityId = db.Activity.FirstOrDefault(c => c.ActivityDescription == "Soccer Game").ActivityId,
                    CreationDate = new DateTime(2017, 3, 10, 0, 0, 5)
                });
                db.Event.Add(new Event
                {
                    DateFrom = new DateTime(2017, 4, 10, 14, 0, 0),
                    DateTo = new DateTime(2017, 4, 10, 17, 0, 0),
                    EventMadeBy = "a",
                    IsActive = true,
                    ActivityId = db.Activity.FirstOrDefault(c => c.ActivityDescription == "Triathalon").ActivityId,
                    CreationDate = new DateTime(2017, 3, 11, 0, 0, 6)
                });
                db.Event.Add(new Event
                {
                    DateFrom = new DateTime(2017, 4, 11, 9, 0, 0),
                    DateTo = new DateTime(2017, 4, 11, 12, 0, 0),
                    EventMadeBy = "Sally",
                    IsActive = true,
                    ActivityId = db.Activity.FirstOrDefault(c => c.ActivityDescription == "Snowboard Tournament").ActivityId,
                    CreationDate = new DateTime(2017, 3, 11, 0, 0, 7)
                });
                db.Event.Add(new Event
                {
                    DateFrom = new DateTime(2017, 4, 15, 14, 0, 0),
                    DateTo = new DateTime(2017, 4, 15, 17, 0, 0),
                    EventMadeBy = "Jordan",
                    IsActive = false,
                    ActivityId = db.Activity.FirstOrDefault(c => c.ActivityDescription == "Triathalon").ActivityId,
                    CreationDate = new DateTime(2017, 3, 11, 0, 0, 8)
                });
                db.Event.Add(new Event
                {
                    DateFrom = new DateTime(2017, 4, 16, 9, 0, 0),
                    DateTo = new DateTime(2017, 4, 16, 10, 0, 0),
                    EventMadeBy = "Sally",
                    IsActive = true,
                    ActivityId = db.Activity.FirstOrDefault(c => c.ActivityDescription == "Basketball Game").ActivityId,
                    CreationDate = new DateTime(2017, 3, 12, 0, 0, 9)
                });
                db.Event.Add(new Event
                {
                    DateFrom = new DateTime(2017, 4, 19, 14, 0, 0),
                    DateTo = new DateTime(2017, 4, 19, 16, 0, 0),
                    EventMadeBy = "Jordan",
                    IsActive = true,
                    ActivityId = db.Activity.FirstOrDefault(c => c.ActivityDescription == "Soccer Game").ActivityId,
                    CreationDate = new DateTime(2017, 3, 12, 0, 0, 10)
                });
                db.Event.Add(new Event
                {
                    DateFrom = new DateTime(2017, 4, 4, 17, 0, 0),
                    DateTo = new DateTime(2017, 4, 4, 20, 0, 0),
                    EventMadeBy = "Jen",
                    IsActive = true,
                    ActivityId = db.Activity.FirstOrDefault(c => c.ActivityDescription == "Potluck").ActivityId,
                    CreationDate = new DateTime(2017, 3, 12, 0, 0, 11)
                });
                db.Event.Add(new Event
                {
                    DateFrom = new DateTime(2017, 4, 21, 19, 0, 0),
                    DateTo = new DateTime(2017, 4, 21, 22, 0, 0),
                    EventMadeBy = "Jen",
                    IsActive = true,
                    ActivityId = db.Activity.FirstOrDefault(c => c.ActivityDescription == "Rock Concert").ActivityId,
                    CreationDate = new DateTime(2017, 3, 12, 0, 0, 12)
                });
                db.Event.Add(new Event
                {
                    DateFrom = new DateTime(2017, 4, 18, 13, 0, 0),
                    DateTo = new DateTime(2017, 4, 18, 17, 0, 0),
                    EventMadeBy = "a",
                    IsActive = true,
                    ActivityId = db.Activity.FirstOrDefault(c => c.ActivityDescription == "Golf Tournament").ActivityId,
                    CreationDate = new DateTime(2017, 3, 12, 0, 0, 13)
                });
                db.Event.Add(new Event
                {
                    DateFrom = new DateTime(2017, 4, 10, 9, 0, 0),
                    DateTo = new DateTime(2017, 4, 10, 10, 0, 0),
                    EventMadeBy = "a",
                    IsActive = false,
                    ActivityId = db.Activity.FirstOrDefault(c => c.ActivityDescription == "Swimming Race").ActivityId,
                    CreationDate = new DateTime(2017, 3, 12, 0, 0, 14)
                });
                db.Event.Add(new Event
                {
                    DateFrom = new DateTime(2017, 4, 16, 12, 0, 0),
                    DateTo = new DateTime(2017, 4, 16, 13, 0, 0),
                    EventMadeBy = "a",
                    IsActive = true,
                    ActivityId = db.Activity.FirstOrDefault(c => c.ActivityDescription == "Doubles Tennis Game").ActivityId,
                    CreationDate = new DateTime(2017, 3, 12, 0, 0, 15)
                });
                db.Event.Add(new Event
                {
                    DateFrom = new DateTime(2017, 4, 8, 16, 0, 0),
                    DateTo = new DateTime(2017, 4, 8, 18, 0, 0),
                    EventMadeBy = "a",
                    IsActive = true,
                    ActivityId = db.Activity.FirstOrDefault(c => c.ActivityDescription == "Family Bowling").ActivityId,
                    CreationDate = new DateTime(2017, 3, 12, 0, 0, 16)
                });

                db.SaveChanges();
            }
        }
    }
}
