using System;

namespace Conferency.Domain
{
    public interface IAuditable
    {
        DateTime ModifiedAt { get; set; }
        DateTime CreatedAt { get; set; }
    }
}