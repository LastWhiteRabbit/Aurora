using API.Entities;
using API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface ITrackRepository
    {
        void Update(Track track);

        Task<bool> SaveAllAsync();
        Task<IEnumerable<TrackDto>> GetTracksAsync();
        Task<TrackDto> GetTrackByIdAsync(int id);
        Task<TrackDto> GetTrackByNameAsync(string name);
        Task<bool> AddNewTrack(TrackDto track);
        Task<PagedList<TrackDto>> GetTracksDtoAsync(UserParams userParams);

    }
}
