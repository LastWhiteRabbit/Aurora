using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BugController : BaseApiController
    {
        private readonly DataContext _context;
        public BugController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "test text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var testing = _context.Users.Find(-1);

            if (testing == null) return NotFound();

            return Ok(testing);
        }


        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var testing = _context.Users.Find(-1);

            var returnTesting = testing.ToString();

            return returnTesting;
        }

        [HttpGet("bad-request")]
        public ActionResult<AppUser> GetBadRequest()
        {
            return BadRequest("Request was not good");
        }
    }
}
