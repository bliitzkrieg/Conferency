using Conferency.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conferency.Data
{
    public interface IConferenceRepository
    {
        void Add<T>(T entity) where T : class;
        Task<bool> SaveAllAsync();

        IEnumerable<Conference> GetAllConferences();
        Conference GetConference(int id);
    }
}
