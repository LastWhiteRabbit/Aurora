using API.Entities;
using API.Interfaces;
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

        public TrackRepository(DataContext context)
        {
            _context = context;
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

        public async Task<IEnumerable<Track>> GetTracksAsync()
        {
            return await _context.Tracks
                .Include(x => x.Genres)
                .Include(x => x.Artists)
                .ToListAsync();
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
