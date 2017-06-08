using Conferency.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conferency.Data
{
    public interface ITalkRepository
    {
        void Add(Talk entity);
        Task<bool> SaveAllAsync();

        void AddWithTags(Talk entity, List<String> tags);
        IEnumerable<Talk> GetAllTalks();
        Talk GetTalk (int id);
    }
}
