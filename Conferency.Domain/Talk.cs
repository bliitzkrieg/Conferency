using System;
using System.Collections.Generic;
using System.Text;

namespace Conferency.Domain
{
    public class Talk
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Url { get; set; }
        public List<Speaker> Speakers { get; set; }
        public DateTime Presented { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
} 
