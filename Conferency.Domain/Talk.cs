﻿using System;
using System.Collections.Generic;

namespace Conferency.Domain
{
    public class Talk : IAuditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<TalkTag> TalkTags { get; set; }
        public DateTime Presented { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
} 
