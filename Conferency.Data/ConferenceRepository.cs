using System.Collections.Generic;
using Conferency.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Conferency.Data
{
    public class ConferenceRepository : IConferenceRepository
    {
        private ConferencyContext _context;

        public ConferenceRepository(ConferencyContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public IEnumerable<Conference> GetAllConferences()
        {
            return _context.Conferences
                .Include(t => t.Talks)
                .Include(c => c.ConferenceSpeakers)
                .ThenInclude(s => s.Speaker)
                .OrderBy(c => c.Hosted)
                .ToList();
        }

        public Conference GetConference(int id)
        {
            return _context.Conferences
                .Include(t => t.Talks)
                .Include(c => c.ConferenceSpeakers)
                .ThenInclude(s => s.Speaker)
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }
    }
}
