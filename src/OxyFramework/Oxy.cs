﻿using OxyFramework.EventManagers;

namespace OxyFramework
{
  // Abother part of this class will be in Engine project
  public partial class Oxy
  {
    public static Graphics Graphics { get; set; }
    public static Resources Resources { get; set; }
    public static GameLifetimeEventManager Events { get; set; }
  }
}