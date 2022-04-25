using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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

        public async Task<TrackDto> GetTrackByIdAsync(int id)
        {
            var track = await _context.Tracks.FindAsync(id);

            return _mapper.Map<TrackDto>(track);
        }

        public async Task<TrackDto> GetTrackByNameAsync(string name)
        {
            var track = await _context.Tracks
                .Include(x=>x.Genres)
                    .ThenInclude(x=>x.Genre)
                .Include(x=>x.Artists)
                    .ThenInclude(x=>x.Artist)
                .SingleOrDefaultAsync(x => x.TrackName == name);

            return _mapper.Map<TrackDto>(track);
        }

        public async Task<IEnumerable<TrackDto>> GetTracksAsync()
        {
            var result = await _context.Tracks
                .Include(x => x.Artists)
                    .ThenInclude(x => x.Artist)
                .Include(x => x.Genres)
                    .ThenInclude(x => x.Genre)
                .ToListAsync();

            return  _mapper.Map<IEnumerable<TrackDto>>(result);
        }

        public async Task<PagedList<TrackDto>> GetTracksDtoAsync(UserParams userParams)
        {
            var query = _context.Tracks
                .Include(x => x.Artists)
                    .ThenInclude(x => x.Artist)
                .Include(x => x.Genres)
                    .ThenInclude(x => x.Genre)
                .ProjectTo<TrackDto>(_mapper.ConfigurationProvider)
                .AsNoTracking();

            return await PagedList<TrackDto>.CreateAsync(query, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddNewTrack(TrackDto track)
        {
            var temp = await _context.AddAsync(_mapper.Map<Track>(track));
            return await SaveAllAsync();
        }

        public void Update(Track track)
        {
            _context.Entry(track).State = EntityState.Modified;
        }
    }
}
