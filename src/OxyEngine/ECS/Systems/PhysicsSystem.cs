
using Microsoft.Xna.Framework;
using OxyEngine.Ecs.Components;
using OxyEngine.Ecs.Entities;
using System.Collections.Generic;
using tainicom.Aether.Physics2D.Dynamics;

namespace OxyEngine.Ecs.Systems
{
  public class PhysicsSystem : GenericSystem
  {
    private World world;
    private Dictionary<PhysicalComponent, Body> _worldObjects;
    public PhysicsSystem(GameEntity rootEntity) : base(rootEntity)
    {
      world = new World(new Vector2(0, 10));
      _worldObjects = new Dictionary<PhysicalComponent, Body>();
      world.CreateEdge(new Vector2(100, 550), new Vector2(700, 550));
    }

    public new void Update(float dt)
    {
      UpdateRecursive(RootEntity, dt);
      world.Step(dt);
      UpdatePositionRecursive(RootEntity);
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

    private void UpdatePositionRecursive(GameEntity entity)
    {
      //((TransformEntity)entity).Transform.Position = new Microsoft.Xna.Framework.Vector2(100, 100);
      foreach (var component in entity.Components)
      {
        if (entity is TransformEntity transformEntity && component is PhysicalComponent physicalComponent)
          transformEntity.Transform.Position = _worldObjects[physicalComponent].Position;
      }
      foreach (var child in entity.Children)
      {
        UpdatePositionRecursive(entity);
      }
    }
    private void TryAdd(float dt, PhysicalComponent component)
    {
      if (!_worldObjects.ContainsKey(component))
      {
        switch (component)
        {
          case CircleColliderComponent circle:
            Body body = new Body();
            body.BodyType = BodyType.Dynamic;
            body.CreateCircle(circle.Radius, 1);
            body.SetRestitution(1f);
            var entity = (TransformEntity)circle.Entity;
            body.Position = entity.Transform.Position;
            _worldObjects[component] = body;
            world.Add(body);
            break;
          default:
            break;
        }
      }
    }
  }
}
