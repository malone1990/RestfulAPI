using RestfulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Data
{
    public interface ITimeCardRepo
    {
        IEnumerable<TimeEntryInfo> GetTimeEntriesByUserId(int userId);

        int AddOrUpdateTimeEntryInfo(TimeEntryInfo timeEntry);

        TimeEntryInfo GetTimeEntryByUserIdAndAnyDay(int userId, DateTime day);

        IEnumerable<TimeCardInfo> GetTimeCardsByUserIdAndEntryId(int userId, int entryId);
    }
}
