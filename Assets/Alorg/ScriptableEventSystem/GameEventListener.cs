using UnityEngine;
using UnityEngine.Events;

namespace Alorg.ScriptableEventSystem
{
  public class GameEventListener : MonoBehaviour
  {
    [SerializeField] GameEvent gameEvent = null;
    [SerializeField] UnityEvent response = null;

    private void OnEnable()
    {
      if (gameEvent)
      {
        gameEvent.AddListener(this);
      }
    }

    private void OnDisable()
    {
      if (gameEvent)
      {
        gameEvent.RemoveListener(this);
      }
    }

    public void RaiseEvent()
    {
      response.Invoke();
    }
  }
}
