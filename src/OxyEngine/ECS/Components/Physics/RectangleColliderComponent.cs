using Microsoft.Xna.Framework;

namespace OxyEngine.Ecs.Components.Physics
{
  public class RectangleColliderComponent : ColliderComponent
  {
    public float Width
    {
      get => size.X;
      set => size.X = value;
    }
    public float Height
    {
      get => size.Y;
      set => size.Y = value;
    }
    private Vector2 size;
    public Vector2 Size
    {
      get => new Vector2(Width, Height);
      set
      {
        if (value.X < 0 || value.Y < 0) throw new System.ArgumentException("Size can't be less than 0");
        size = value;
      }
    }

    public RectangleColliderComponent(Vector2 size)
    {
      Size = size;
    }
    public RectangleColliderComponent(float width, float height) : this(new Vector2(width, height)){}
    public RectangleColliderComponent() : this(new Vector2(50, 50)){}
  }
}
