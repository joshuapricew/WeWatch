using System;

namespace WeWatch
{
    public class Client
    {
        public readonly Guid Uuid = Guid.NewGuid();
        public bool IsHost { get; init; } = false;
        public bool IsPlaying {get; private set; }

        public void Pause()
        {
            // TODO: Add code to send the instruction to the client.
            IsPlaying = false;
        }

        public void Play()
        {
            // TODO: Add code to send the instruction to the client.
            IsPlaying = true;
        }
    }
}