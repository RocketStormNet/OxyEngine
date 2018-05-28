
using OxyEngine.Ecs.Behaviours;

namespace OxyEngine.Ecs.Components
{
  public class CircleColliderComponent : PhysicalComponent
  {
    public float Radius { get; set; }

    public CircleColliderComponent()
    {
      Radius = 100;
    }
  }
}
