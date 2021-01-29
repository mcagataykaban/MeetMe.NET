using MeetMe.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetMe.ViewComponents
{
    public class UpcomingEventViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public UpcomingEventViewComponent(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var meeting = _db.Meetings
                .Where(x => x.MeetingTime > DateTime.Now)
                .OrderBy(x => x.MeetingTime)
                .FirstOrDefault();
            return View(meeting);
        }
    }
}
