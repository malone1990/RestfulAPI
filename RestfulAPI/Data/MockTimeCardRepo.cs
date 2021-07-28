using RestfulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Data
{
    public class MockTimeCardRepo : ITimeCardRepo
    {
        int ITimeCardRepo.AddOrUpdateTimeEntryInfo(TimeEntryInfo timeEntry)
        {
            Console.WriteLine(timeEntry!=null ?timeEntry.ToString():"NULL");
            return 0;
        }

        IEnumerable<TimeCardInfo> ITimeCardRepo.GetTimeCardsByUserIdAndEntryId(int userId, int entryId)
        {
            var card = new TimeCardInfo { TiemCardId = 0, TimeEntryId = 0, MonInfo = 8, ThuInfo = 4.0, FriInfo = 4.5, WedInfo = 3.8 };
            return new List<TimeCardInfo> { card };
        }

        IEnumerable<TimeEntryInfo> ITimeCardRepo.GetTimeEntriesByUserId(int userId)
        {
            var user = new UserInfo { UserId = userId, Name = "test" };
            var TimeCard = new TimeCardInfo { TiemCardId = 0, TimeEntryId = 0, MonInfo = 8, ThuInfo = 4.0, FriInfo = 4.5,WedInfo=3.8 };
            var entry1 = new TimeEntryInfo() { User = user, DateFrom = DateTime.Parse("2021-7-12"), DateTo = DateTime.Parse("2021-7-18"), TimeEntryId = 0};
            var entry2 = new TimeEntryInfo() { User = user, DateFrom = DateTime.Parse("2021-7-19"), DateTo = DateTime.Parse("2021-7-25"), TimeEntryId = 1 };
            var entry3 = new TimeEntryInfo() { User = user, DateFrom = DateTime.Parse("2021-7-26"), DateTo = DateTime.Parse("2021-8-01"), TimeEntryId = 3 };
            return new List<TimeEntryInfo> { entry1, entry2, entry3 };
        }

        TimeEntryInfo ITimeCardRepo.GetTimeEntryByUserIdAndAnyDay(int userId, DateTime day)
        {
            var user = new UserInfo { UserId = userId, Name = "test" };
            var TimeCard = new TimeCardInfo { TiemCardId = 0, TimeEntryId = 0, MonInfo = 8, ThuInfo = 4.0, FriInfo = 4.5, WedInfo = 3.8 };
            var entry1 = new TimeEntryInfo() { User = user, DateFrom = day.AddDays(-7), DateTo = day, TimeEntryId = 0 };
            return entry1;
        }
    }
}
