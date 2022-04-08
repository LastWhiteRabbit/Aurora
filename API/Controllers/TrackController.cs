using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class TrackController : BaseApiController
    {
        private readonly ITrackRepository _trackRepository;

        public TrackController(ITrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrackDto>>> GetTracks()
        {
            var tracks = await _trackRepository.GetTracksAsync();
            return Ok(tracks);
        }
        [HttpGet("{trackName}")]
        public async Task<ActionResult<Track>> GetTracks(string trackName)
        {
            return await _trackRepository.GetTrackByNameAsync(trackName);
        }

    }
}
