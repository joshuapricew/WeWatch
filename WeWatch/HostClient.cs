using System;

namespace WeWatch
{
    class HostClient : Client
    {
        public override bool IsHost { get; init; } = true;
        
    }
}