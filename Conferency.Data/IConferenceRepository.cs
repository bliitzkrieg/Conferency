using Conferency.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conferency.Data
{
    public interface IConferenceRepository
    {
        void Add<T>(T entity) where T : class;
        IEnumerable<Conference> GetAllConferences();
        Conference GetConference(int id);
    }
}
