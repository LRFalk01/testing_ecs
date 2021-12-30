using DefaultEcs;
using DefaultEcs.System;

namespace testing_ecs;

public class ClientPacketLoopSystem : ISystem<long>
{
    private readonly SequentialSystem<long> _system;

    public ClientPacketLoopSystem(World world)
    {
        _system = new SequentialSystem<long>(new PingSystem(world));
    }

    public void Update(long state)
    {
        _system.Update(state);
    }

    public bool IsEnabled { get; set; }

    public void Dispose()
    {
        _system.Dispose();
    }
}