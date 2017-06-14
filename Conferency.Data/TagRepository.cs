using System;
using System.Collections.Generic;
using Conferency.Domain;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Conferency.Data
{
    public class TagRepository: ITagRepository
    {
        private ConferencyContext _context;

        public TagRepository(ConferencyContext context)
        {
            _context = context;
        }

        public void Add(Tag entity)
        {
            _context.Add(entity);
        }

        public List<Tag> FindOrCreateTags(List<string> tags)
        {
            List<Tag> _tags = new List<Tag>();
            tags.ForEach(t =>
            {
                var tag = _context.Tags
                    .Where(c => c.Name == t)
                    .FirstOrDefault();

                if (tag != null)
                {
                    _tags.Add(tag);
                }
                else
                {
                    Tag created = new Tag { Name = t };
                    this.Add(created);
                    _tags.Add(created);
                }
            });

            return _tags;
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
