
using Microsoft.Xna.Framework;
using OxyEngine.Ecs.Components;
using OxyEngine.Ecs.Entities;
using System.Collections.Generic;
using tainicom.Aether.Physics2D.Common;
using tainicom.Aether.Physics2D.Dynamics;

namespace OxyEngine.Ecs.Systems
{
  public class PhysicsSystem : GenericSystem
  {
    private const int scale = 10;

    private World world;
    private Dictionary<PhysicalComponent, Body> worldObjects;
    public PhysicsSystem(GameEntity rootEntity) : base(rootEntity)
    {
      world = new World(new Vector2(0, 10));
      worldObjects = new Dictionary<PhysicalComponent, Body>();
    }

    public new void Update(float dt)
    {
      UpdateRecursive(RootEntity, dt);
      world.Step(dt);
      UpdateEntitiesRecursive(RootEntity);
    }

    public void UpdateRecursive(GameEntity entity, float dt)
    {
      foreach (var component in entity.Components)
      {
        if (component is PhysicalComponent physicalComponent)
          TryAdd(dt, physicalComponent);
      }

      foreach (var child in entity.Children)
      {
        UpdateRecursive(child, dt);
      }
    }

    private void UpdateEntitiesRecursive(GameEntity entity)
    {
      foreach (var component in entity.Components)
      {
        if (entity is TransformEntity transformEntity && component is PhysicalComponent physicalComponent)
        {
          transformEntity.Transform.Position = worldObjects[physicalComponent].Position * scale;
          transformEntity.Transform.Rotation = worldObjects[physicalComponent].Rotation;
        }
      }
      foreach (var child in entity.Children)
      {
        UpdateEntitiesRecursive(child);
      }
    }
    private void TryAdd(float dt, PhysicalComponent component)
    {
      if (!worldObjects.ContainsKey(component))
      {
        Body body = new Body();
        body.SleepingAllowed = false;
        body.BodyType = component.type;
        var entity = (TransformEntity)component.Entity;
        body.Position = entity.Transform.GlobalPosition / scale;
        body.Rotation = entity.Transform.Rotation;
        switch (component)
        {
          case CircleColliderComponent circle:
            body.CreateCircle(circle.Radius / scale, 1);
            break;
          case RectangleColliderComponent rectangle:
            body.CreateRectangle(rectangle.Width / scale, rectangle.Height / scale, 1, Vector2.Zero);
            break;
          case PolygonColliderComponent polygon:
            for (var i = 0; i < polygon.Points.Count; i++)
            {
              polygon.Points[i] /= scale;
            }
            body.CreatePolygon(new Vertices(polygon.Points), 1);
            break;
          case EdgeColliderComponent edge:
            body.CreateEdge(edge.Start / scale, edge.End / scale);
            break;
          default:
            break;
        }
        body.SetRestitution(0.5f);
        worldObjects[component] = body;
        world.Add(body);
      }
    }
  }
}
