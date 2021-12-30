using DefaultEcs;

namespace testing_ecs;

public static class Program
{
    private static World _world;
    private static PingSystem _pingSystem;

    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        _world = new World();
        _pingSystem = new PingSystem(_world);

        var entity1 = _world.CreateEntity();
        entity1.Set(new PingRequest("1"));

        var entity2 = _world.CreateEntity();
        entity2.Set(new PingRequest("2"));

        // var entity3 = _world.CreateEntity();
        // entity3.Set(new PingRequest("3"));

        var ticks = DateTime.UtcNow.Ticks;
        _pingSystem.Update(ticks);

        // if entity is disposed outside of a system, it works
        // entity1.Dispose();

        // run again system tries to run for the correct entity, but thinks it is not alive
        _pingSystem.Update(ticks);
    }
}