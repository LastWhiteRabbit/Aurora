using API.Entities;
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
        Task<IEnumerable<Track>> GetTracksAsync();
        Task<Track> GetTrackByIdAsync(int id);
        Task<Track> GetTrackByNameAsync(string name);
    }
}
