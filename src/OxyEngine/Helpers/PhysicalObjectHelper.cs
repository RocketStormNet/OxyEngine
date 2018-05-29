using Microsoft.Xna.Framework;
using OxyEngine.Ecs.Components.Physics;
using OxyEngine.Ecs.Entities;
using System.Collections.Generic;
using tainicom.Aether.Physics2D.Dynamics;

namespace OxyEngine.Helpers
{
  public static class PhysicalObjectHelper
  {
    public static TransformEntity GetPhysicalVisualCircle(Vector2 position, float rotation, BodyType type, float radius = 10)
    {
      var circle = new TransformEntity();
      var physicsBodyComponent = new PhysicsBodyComponent(position, rotation, type);
      circle.AddComponent(physicsBodyComponent);
      var circleCollider = new CircleColliderComponent(radius);
      physicsBodyComponent.AddColliderVisual(circleCollider);
      return circle;
    }

    public static TransformEntity GetPhysicalVisualRectangle(Vector2 position, float rotation, BodyType type, Vector2 size)
    {
      var rectangle = new TransformEntity();
      var physicsBodyComponent = new PhysicsBodyComponent(position, rotation, type);
      rectangle.AddComponent(physicsBodyComponent);
      var rectangleCollider = new RectangleColliderComponent(size);
      physicsBodyComponent.AddColliderVisual(rectangleCollider);
      return rectangle;
    }
    public static TransformEntity GetPhysicalVisualRectangle(Vector2 position, float rotation, BodyType type, float width = 10, float height = 10)
    {
      return GetPhysicalVisualRectangle(position, rotation, type, new Vector2(width, height));
    }
    public static TransformEntity GetPhysicalVisualRectangle(Vector2 position, float rotation, BodyType type, float side = 10)
    {
      return GetPhysicalVisualRectangle(position, rotation, type, new Vector2(side, side));
    }

    public static TransformEntity GetPhysicalVisualPolygon(Vector2 position, float rotation, BodyType type, List<Vector2> vertices)
    {
      var polygon = new TransformEntity();
      var physicsBodyComponent = new PhysicsBodyComponent(position, rotation, type);
      polygon.AddComponent(physicsBodyComponent);
      var polygonCollider = new PolygonColliderComponent(vertices);
      physicsBodyComponent.AddColliderVisual(polygonCollider);
      return polygon;
    }
  }
}
