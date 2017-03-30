using System;
using System.Collections.Generic;
using System.Text;

namespace Conferency.Domain
{
    public class ConferenceSpeaker
    {
        public int SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
        public int ConferenceId { get; set; }
        public Conference Conference { get; set; }
    }
}
