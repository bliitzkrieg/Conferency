using System;
using System.Collections.Generic;
using System.Text;

namespace Conferency.Domain
{
    public class SpeakerTalk
    {
        public int SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
        public int TalkId { get; set; }
        public Talk Talk { get; set; }
    }
}
