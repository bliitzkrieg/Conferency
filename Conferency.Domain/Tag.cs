using System;
using System.Collections.Generic;

namespace Conferency.Domain
{
    public class Tag : IAuditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TalkTag> TalkTags { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
