
using Microsoft.Xna.Framework;

namespace OxyEngine.Ecs.Components
{
  public class EdgeColliderComponent : PhysicalComponent
  {
    public Vector2 Start;
    public Vector2 End;

    public EdgeColliderComponent()
    {
      Start = new Vector2(0, 0);
      End = new Vector2(10, 0);
    }
  }
}
