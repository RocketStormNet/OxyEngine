using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using tainicom.Aether.Physics2D.Dynamics;

namespace OxyEngine.Ecs.Components.Physics
{
  public class PhysicsBodyComponent : GameComponent
  {
    public Queue<ColliderComponent> CollidersQueue;
    public List<ColliderComponent> Colliders;
    public bool UpdateNeeded { get; set; }

    public Vector2 Position { get; set; }
    public float Rotation { get; set; }
    public BodyType Type;

    public PhysicsBodyComponent(Vector2 position = default, float rotation = 0, BodyType type = BodyType.Static)
    {
      Position = position;
      Rotation = rotation;
      Type = type;

      Colliders = new List<ColliderComponent>();
      CollidersQueue = new Queue<ColliderComponent>();
    }

    public void AddCollider(ColliderComponent collider)
    {
      if (collider == null)
        throw new ArgumentNullException(nameof(collider));

      CollidersQueue.Enqueue(collider);
    }

    public T AddCollider<T>() where T : ColliderComponent
    {
      var collider = Activator.CreateInstance<T>();

      AddCollider(collider);

      return collider;
    }

    public void AddColliderVisual(ColliderComponent collider)
    {
      switch (collider)
      {
        case CircleColliderComponent circleCollider:
          var circleComp = new CircleComponent();
          circleComp.Radius = circleCollider.Radius;
          Entity.AddComponent(circleComp);
          break;
        case RectangleColliderComponent rectangleCollider:
          var rectangleComp = new RectangleComponent();
          int w = (int)rectangleCollider.Width;
          int h = (int)rectangleCollider.Height;
          rectangleComp.Rectangle = new Rectangle(-w/2, -h/2, w, h);
          Entity.AddComponent(rectangleComp);
          break;
        case EdgeColliderComponent edgeCollider:
          var edgeComp = new LineComponent();
          edgeComp.From = edgeCollider.Start;
          edgeComp.To = edgeCollider.End;
          Entity.AddComponent(edgeCollider);
          break;
        case PolygonColliderComponent polygonCollider:
          //var Points = new List<Vector2>();
          //Points.Add(new Vector2(20, 20));
          //Points.Add(new Vector2(20, -20));
          //Points.Add(new Vector2(-20, -20));
          //Points.Add(new Vector2(-20, 20));
          //polygonCollider.Points.AddRange(Points);
          var polyComp = new PolygonComponent();
          polyComp.Points.AddRange(polygonCollider.Points);
          polyComp.Points.Add(polygonCollider.Points[0]);
          Entity.AddComponent(polyComp);
          break;
        default:
          break;


      }
      if (collider == null)
        throw new ArgumentNullException(nameof(collider));

      CollidersQueue.Enqueue(collider);
    }

    public T AddColliderVisual<T>() where T : ColliderComponent
    {
      var collider = Activator.CreateInstance<T>();

      AddColliderVisual(collider);

      return collider;
    }
  }
}
