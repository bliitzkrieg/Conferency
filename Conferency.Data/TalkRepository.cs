using System.Collections.Generic;
using Conferency.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Conferency.Data
{
    public class TalkRepository : ITalkRepository
    {
        private ConferencyContext _context;

        public TalkRepository(ConferencyContext context)
        {
            _context = context;
        }

        public void Add(Talk entity)
        {
            _context.Add(entity);
        }

        public void AddWithTags(Talk entity, List<String> tags)
        {
            // What to do here.
        }

        public IEnumerable<Talk> GetAllTalks()
        {
            return _context.Talks
                .Include(c => c.TalkTags)
                .OrderBy(c => c.Presented)
                .ToList();
        }

        public Talk GetTalk(int id)
        {
            return _context.Talks
                .Include(c => c.TalkTags)
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
