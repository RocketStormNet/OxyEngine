
using Microsoft.Xna.Framework;

namespace OxyEngine.Ecs.Components.Physics
{
  public abstract class ColliderComponent : GameComponent, Behaviours.ILoadable
  {
    public Vector2 Position { get; set; }
    public ColliderComponent()
    {
      Position = new Vector2();
    }

    public void Load()
    {
      RequireComponent<PhysicsBodyComponent>();
    }
  }
}
