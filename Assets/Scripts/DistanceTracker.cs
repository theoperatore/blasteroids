using System.Collections;
using UnityEngine;

public class DistanceTracker : MonoBehaviour
{
  [SerializeField] private Attribute distance;
  private Coroutine tracker;
  private bool started = false;

  public void Reset()
  {
    distance.value = 0;
  }

  public void StartTracking()
  {
    started = true;
  }

  public void StopTracking()
  {
    started = false;
  }

  private void Update()
  {
    if (started)
    {
      distance.value += 0.25f * Time.deltaTime * 10;
    }
  }
}
