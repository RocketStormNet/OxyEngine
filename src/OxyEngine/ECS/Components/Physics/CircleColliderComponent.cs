
namespace OxyEngine.Ecs.Components.Physics
{
  public class CircleColliderComponent : ColliderComponent
  {
    private float radius;
    public float Radius
    {
      get => radius;
      set
      {
        if (value < 0) throw new System.ArgumentException("Radius can't be less that 0");
        radius = value;
      }
    }
    public CircleColliderComponent(float radius)
    {
      this.radius = radius;
    }

    public CircleColliderComponent() : this(100)
    {
    }
  }
}
