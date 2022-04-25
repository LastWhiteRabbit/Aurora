using API.Data;
using API.Entities;
using API.Helpers;
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
        public async Task<ActionResult<IEnumerable<TrackDto>>> GetUsers([FromQuery] UserParams userParams)
        {
            var users = await _trackRepository.GetTracksDtoAsync(userParams);

            Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);

            return Ok(users);
        }


        [HttpGet("{trackName}")]
        public async Task<ActionResult<TrackDto>> GetTrack(string trackName)
        {
            return await _trackRepository.GetTrackByNameAsync(trackName);
        }


        [HttpPost("add-new-track")]
        public async Task<ActionResult<bool>> AddTrack(TrackDto track)
        {
            return await _trackRepository.AddNewTrack(track);
        }

    }
}
