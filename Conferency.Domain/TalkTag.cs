using System;
using System.Collections.Generic;
using System.Text;

namespace Conferency.Domain
{
    public class TalkTag
    {
        public int TalkId { get; set; }
        public Talk Talk { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
