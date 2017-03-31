using System;
using System.Collections.Generic;

namespace Conferency.Domain
{
    public class Conference : IAuditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public List<ConferenceSpeaker> ConferenceSpeakers { get; set; }
        public List<Talk> Talks { get; set; }
        public DateTime Hosted { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
