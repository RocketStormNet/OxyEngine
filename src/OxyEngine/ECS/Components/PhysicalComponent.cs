
using tainicom.Aether.Physics2D.Dynamics;

namespace OxyEngine.Ecs.Components
{
  public abstract class PhysicalComponent : GameComponent
  {
    public BodyType type { get; set; }

    public PhysicalComponent()
    {
      type = BodyType.Static;
    }
  }
}
