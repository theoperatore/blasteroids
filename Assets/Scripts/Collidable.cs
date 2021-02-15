using System;
using UnityEngine;

public class Collidable : MonoBehaviour
{

  public event Action<float> OnCollisionWithForce;

  // 10 collision points is prolly enough for this simple game?
  // reuse this array for each collision so we don't create
  // a bunch of garbage
  private ContactPoint2D[] points = new ContactPoint2D[10];

  private void OnCollisionEnter2D(Collision2D other)
  {
    var force = GetCollisionForce(other);

    // ? behaves the same in javascript.
    // I wonder though, is it better to have the NullPointException
    // thrown or hide it with the ?...hmmm
    OnCollisionWithForce?.Invoke(force);
  }

  private float GetCollisionForce(Collision2D collision)
  {
    float impulse = 0f;
    collision.GetContacts(points);

    foreach (var point in points)
    {
      impulse += point.normalImpulse;
    }

    return impulse / Time.fixedDeltaTime;
  }
}
