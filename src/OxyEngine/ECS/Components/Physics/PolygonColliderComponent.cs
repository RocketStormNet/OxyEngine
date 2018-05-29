
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace OxyEngine.Ecs.Components.Physics
{
  public class PolygonColliderComponent : ColliderComponent
  {
    public List<Vector2> Points;

    public PolygonColliderComponent(List<Vector2> points)
    {
      Points = points;
    }
    public PolygonColliderComponent() : this(new List<Vector2>()){}
  }
}
