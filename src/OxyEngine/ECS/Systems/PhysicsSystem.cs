using Microsoft.Xna.Framework;
using OxyEngine.Ecs.Components.Physics;
using OxyEngine.Ecs.Entities;
using System.Collections.Generic;
using tainicom.Aether.Physics2D.Collision.Shapes;
using tainicom.Aether.Physics2D.Common;
using tainicom.Aether.Physics2D.Dynamics;

namespace OxyEngine.Ecs.Systems
{
  public class PhysicsSystem : GenericSystem
  {
    private const int scale = 30;

    private World world;
    private Dictionary<PhysicsBodyComponent, Body> worldObjects;
    public PhysicsSystem(GameEntity rootEntity) : base(rootEntity)
    {
      world = new World(new Vector2(0, 10));
      worldObjects = new Dictionary<PhysicsBodyComponent, Body>();
    }

    public new void Update(float dt)
    {
      UpdateRecursive(RootEntity);
      world.Step(dt);
      UpdateEntitiesRecursive(RootEntity);
    }

    public void UpdateRecursive(GameEntity entity)
    {
      foreach (var component in entity.Components)
      {
        if (component is PhysicsBodyComponent body)
          ProcessBody(body);
      }

      foreach (var child in entity.Children)
      {
        UpdateRecursive(child);
      }
    }

    private void UpdateEntitiesRecursive(GameEntity entity)
    {
      foreach (var component in entity.Components)
      {
        if (component is PhysicsBodyComponent body && entity is TransformEntity transformEntity)
        {
          transformEntity.Transform.Position = worldObjects[body].Position * scale;
          transformEntity.Transform.Rotation = worldObjects[body].Rotation;
        }
      }
      foreach (var child in entity.Children)
      {
        UpdateEntitiesRecursive(child);
      }
    }
    private void ProcessBody(PhysicsBodyComponent bodyComponent)
    {
      Body body;
      if (!worldObjects.ContainsKey(bodyComponent))
      {
        body = world.CreateBody(bodyComponent.Position / scale, bodyComponent.Rotation, bodyComponent.Type);
        body.SleepingAllowed = false;
        worldObjects[bodyComponent] = body;
      }
      else
      {
        body = worldObjects[bodyComponent];
      }
      while (bodyComponent.CollidersQueue.Count > 0)
      {
        ColliderComponent collider = bodyComponent.CollidersQueue.Dequeue();
        bodyComponent.Colliders.Add(collider);

        switch (collider)
        {
          case CircleColliderComponent circle:
            body.CreateCircle(circle.Radius / scale, 1, circle.Position);
            break;
          case RectangleColliderComponent rectangle:
            body.CreateRectangle(rectangle.Width / scale, rectangle.Height / scale, 1, Vector2.Zero);
            break;
          case PolygonColliderComponent polygon:
            List<Vector2> vertices = new List<Vector2>();
            for (var i = 0; i < polygon.Points.Count; i++)
            {
              vertices.Add(polygon.Points[i] / scale);
            }
            body.CreatePolygon(new Vertices(vertices), 1);
            break;
          case EdgeColliderComponent edge:
            body.CreateEdge(edge.Start / scale, edge.End / scale);
            break;
          default:
            break;
        }
        body.SetRestitution(0.5f);
      }
    }
  }
}
