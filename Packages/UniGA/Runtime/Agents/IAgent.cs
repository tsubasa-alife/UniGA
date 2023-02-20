using System;

namespace UniGA
{
    public interface IAgent
    {
        // Agentが持つ遺伝子の個数
        int Length { get; }

    }
}
