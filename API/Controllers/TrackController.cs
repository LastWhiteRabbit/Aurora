using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackController : ControllerBase
    {
        private readonly DataContext _db;

        public TrackController(DataContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Track>>> GetTracks()
        {
            return await _db.Tracks.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Track>> GetTracks(int id)
        {
            return await _db.Tracks.FindAsync(id);
        }

    }
}
