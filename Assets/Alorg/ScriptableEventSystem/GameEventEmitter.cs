using UnityEngine;

namespace Alorg.ScriptableEventSystem
{
  public class GameEventEmitter : MonoBehaviour
  {
    public GameEvent gameStartEvent;
    public bool raiseOnStart = true;

    // Start is called before the first frame update
    void Start()
    {
      if (raiseOnStart)
      {
        gameStartEvent?.Raise();
      }
    }
  }
}
