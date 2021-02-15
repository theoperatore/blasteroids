using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Player : MonoBehaviour
{
  public float maxSpeed = 3f;
  public Sprite neutral = default;
  public Sprite up = default;
  public Sprite down = default;
  public GameObject weaponPoint = default;
  public GameObject projectile = default;
  public GameObject deathExplosion = default;
  public float projectileSpeed = 10f;
  public float weaponCooldownTime = 0f;
  public float shieldStrength = 250f;
  public CinemachineImpulseSource impulseSource = default;

  private Health health;
  private Collidable collideable;
  private SpriteRenderer sprite;
  private Rigidbody2D rb;
  private InputMaster controls;
  private float currWeaponCooldownTime = 0f;

  private void Awake()
  {
    controls = new InputMaster();
    controls.Player.Shoot.performed += Shoot;
    controls.Player.Movement.performed += Move;
    controls.Player.Movement.canceled += MoveCancelled;

    rb = GetComponent<Rigidbody2D>();
    sprite = GetComponentInChildren<SpriteRenderer>();
    collideable = GetComponent<Collidable>();
    health = GetComponent<Health>();

    collideable.OnCollisionWithForce += HandleCollide;
  }

  private void OnEnable()
  {
    controls.Enable();
  }

  private void OnDisable()
  {
    controls.Disable();
  }

  private void Update()
  {
    currWeaponCooldownTime = Mathf.Max(currWeaponCooldownTime - Time.deltaTime, 0);
  }

  private void Shoot(InputAction.CallbackContext obj)
  {
    if (currWeaponCooldownTime > 0) return;

    currWeaponCooldownTime = weaponCooldownTime;
    var gobj = Instantiate(projectile, weaponPoint.transform.position, Quaternion.identity);
    gobj.GetComponent<Rigidbody2D>().velocity = Vector2.right * projectileSpeed;
  }

  private void Move(InputAction.CallbackContext ctx)
  {
    var direction = ctx.ReadValue<Vector2>();
    rb.velocity = direction * maxSpeed;

    if (direction.y < 0)
    {
      sprite.sprite = down;
    }
    else if (direction.y > 0)
    {
      sprite.sprite = up;
    }
    else
    {
      sprite.sprite = neutral;
    }
  }

  private void MoveCancelled(InputAction.CallbackContext ctx)
  {
    rb.velocity = Vector2.zero;
    sprite.sprite = neutral;
  }

  private void HandleCollide(float force)
  {
    if (force > shieldStrength)
    {
      health.TakeDamage(1);
    }
  }

  public void Explode()
  {
    impulseSource?.GenerateImpulse();
    transform.GetChild(0)?.gameObject.SetActive(false);
    var expl = Instantiate(deathExplosion, transform);
    Destroy(expl, 1f);
  }
}
