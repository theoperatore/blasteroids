using System.Collections.Generic;
using UnityEngine;

namespace Alorg.ScriptableEventSystem
{
  [CreateAssetMenu(fileName = "GameEvent", menuName = "Alorg/GameEvent", order = 0)]
  public class GameEvent : ScriptableObject
  {
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void AddListener(GameEventListener listener)
    {
      listeners.Add(listener);
    }

    public bool RemoveListener(GameEventListener listener)
    {
      if (listeners.Contains(listener))
      {
        listeners.Remove(listener);
        return true;
      }

      return false;
    }

    public void Raise()
    {
      for (var i = listeners.Count - 1; i >= 0; i--)
      {
        listeners[i].RaiseEvent();
      }
    }
  }
}
