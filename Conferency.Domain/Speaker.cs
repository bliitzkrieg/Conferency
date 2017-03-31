using System;
using System.Collections.Generic;

namespace Conferency.Domain
{
    public class Speaker : IAuditable
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string Photo { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string Website { get; set; }
        public string Github { get; set; }
        public string Twitter { get; set; }
        public List<ConferenceSpeaker> ConferenceSpeakers { get; set; }
        public List<SpeakerTalk> SpeakerTalks { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
