using UnityEngine;

public class Projectile : MonoBehaviour
{
  public GameObject explosion = default;

  private SpriteRenderer sprite = default;
  private Rigidbody2D rb = default;
  private Collider2D col = default;

  private void Awake()
  {
    sprite = GetComponent<SpriteRenderer>();
    rb = GetComponent<Rigidbody2D>();
    col = GetComponent<Collider2D>();
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Asteroid")
    {
      ShowHitAndDestroy();

      var health = other.gameObject.GetComponent<Health>();
      health.TakeDamage(1f);

      if (health.current <= 0)
      {
        Destroy(other.gameObject);
      }
      else
      {
        // show damage visual
      }
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Asteroid")
    {
      ShowHitAndDestroy();

      var health = other.GetComponent<Health>();
      health.TakeDamage(1f);

      if (health.current <= 0)
      {
        Destroy(other.gameObject);
      }
      else
      {
        // show damage visual
      }

    }
  }

  private void ShowHitAndDestroy()
  {
    var expl = Instantiate(explosion, transform);
    rb.velocity = Vector2.zero;

    // hide and disable collisions until this object can be destroyed.
    sprite.enabled = false;
    col.enabled = false;
    Destroy(expl, 0.5f);
    Destroy(gameObject, 0.5f);
  }

}
