using Conferency.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conferency.Data
{
    public interface ITagRepository
    {
        void Add(Tag entity);
        Task<bool> SaveAllAsync();

        List<Tag> FindOrCreateTags(List<String> tags);
    }
}
