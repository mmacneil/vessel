using System.Collections.Generic;

namespace Vessel
{
    public interface IDto<out T>
    {
        Status Status { get; }
        IEnumerable<string> Errors { get; }
        T Payload { get; }
    }
}
