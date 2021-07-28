using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI.Data;
using RestfulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TimeCardController : ControllerBase
    {
        private readonly ITimeCardRepo _repository;

        public TimeCardController(ITimeCardRepo repository)
        {
            _repository = repository;
        }

        [HttpGet("entry/{userid}")]
        public ActionResult<TimeEntryInfo> GetTimeEntriesByUserId(int userid)
        {
            var user = _repository.GetTimeEntriesByUserId(userid);
            if (user == null)
                return new EmptyResult();
            return Ok(user);
        }

        [HttpGet("entry/{userid}/{entryId}")]
        public ActionResult<TimeEntryInfo> GetTimeCardsByUserIdAndEntryId(int userid, int entryId)
        {
            var user = _repository.GetTimeEntriesByUserId(userid);
            if (user == null)
                return new EmptyResult();
            return Ok(user);
        }

    }
}
