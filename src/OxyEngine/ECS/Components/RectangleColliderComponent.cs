using Microsoft.Xna.Framework;

namespace OxyEngine.Ecs.Components
{
  public class RectangleColliderComponent : PhysicalComponent
  {
    public float X { get; set; }
    public float Y { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public Vector2 AddPosition;
    public Vector2 Position
    {
      get => new Vector2(X, Y);
      set
      {
        X = value.X;
        Y = value.Y;
      }
    }
    public Vector2 Size
    {
      get => new Vector2(Width, Height);
      set
      {
        Width = value.X;
        Height = value.Y;
      }
    }

    public RectangleColliderComponent()
    {
      Position = new Vector2();
      Size = new Vector2(10, 10);
    }
  }
}
