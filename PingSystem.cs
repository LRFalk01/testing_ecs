using DefaultEcs;
using DefaultEcs.System;

namespace testing_ecs
{

    public class PingSystem : AEntitySetSystem<long>
    {
        public PingSystem(World world)
            : base(world.GetEntities()
                    .With<PingRequest>()
                    .AsSet())
        {
        }

        protected override void Update(long state, in Entity entity)
        {
            if (!entity.IsAlive)
            {
                Console.WriteLine($"{entity}: is not alive");
                return;
            }

            ref var ping = ref entity.Get<PingRequest>();
            Console.WriteLine($"{entity}: ping {ping.Name}");

            // change this to a 2, and it works.
            // I suspect this has something to do with needing to remove entities in the order in which they were created
            if (ping.Name == "1")
            {
                // disposing an entity within a system appears to have a negative effect on the world.
                // it appears as if instead of disposing the entity requested, it disposes the last entity in the world.
                // if instead the entity is disabled, the world will continue as expected.
                entity.Dispose();
            }
        }
    }

    public struct PingRequest
    {
        public readonly string Name;

        public PingRequest(string name)
        {
            Name = name;
        }
    }
}