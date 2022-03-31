using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class TrackRepository : ITrackRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TrackRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Track> GetTrackByIdAsync(int id)
        {
            return await _context.Tracks.FindAsync(id);
        }

        public async Task<Track> GetTrackByNameAsync(string name)
        {
            return await _context.Tracks
                .SingleOrDefaultAsync(x => x.TrackName == name);
        }

        public async Task<IEnumerable<TrackDto>> GetTracksAsync()
        {
            var result = await _context.Tracks.ToListAsync();

            return _mapper.Map<List<TrackDto>>(result);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Track track)
        {
            _context.Entry(track).State = EntityState.Modified;
        }
    }
}
