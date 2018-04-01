﻿using System.Collections.Generic;
using OxyEngine.ECS.Components;
using OxyEngine.Events;

namespace OxyEngine.ECS.Systems
{
  public abstract class BaseGameSystem
  {
    public readonly string Name;
    private EventSystem _eventSystem;
    private ICollection<BaseGameComponent> _components;
    
    protected BaseGameSystem(string name)
    {
      Name = name;
      _eventSystem = new EventSystem();
    }

    public void AddComponent(BaseGameComponent component)
    {
      _components.Add(component);
    }
    
    public void RemoveComponent(BaseGameComponent component)
    {
      _components.Remove(component);
    }
  }
}