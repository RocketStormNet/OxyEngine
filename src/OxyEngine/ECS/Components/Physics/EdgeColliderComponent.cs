
using Microsoft.Xna.Framework;

namespace OxyEngine.Ecs.Components.Physics
{
  public class EdgeColliderComponent : ColliderComponent
  {
    public Vector2 Start { get; set; }
    public Vector2 End { get; set; }

    public EdgeColliderComponent()
    {
      Start = new Vector2(0, 0);
      End = new Vector2(50, 0);
    }
  }
}
