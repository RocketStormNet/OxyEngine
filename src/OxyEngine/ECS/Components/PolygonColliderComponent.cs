
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace OxyEngine.Ecs.Components
{
  public class PolygonColliderComponent : PhysicalComponent
  {
    public List<Vector2> Points;

    public PolygonColliderComponent()
    {
      Points = new List<Vector2>();
    }
  }
}
