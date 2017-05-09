using Conferency.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conferency.Data
{
    public interface ITalkRepository
    {
        void Add<T>(T entity) where T : class;
        Task<bool> SaveAllAsync();

        IEnumerable<Talk> GetAllTalks();
        Talk GetTalk (int id);
    }
}
