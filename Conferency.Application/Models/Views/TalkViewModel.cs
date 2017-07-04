using System;
using System.Collections.Generic;

namespace Conferency.Application.Models
{
    public class TalkViewModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public List<String> Tags { get; set; }
    }
}
