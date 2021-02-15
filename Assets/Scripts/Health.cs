using Alorg.ScriptableEventSystem;
using UnityEngine;

public class Health : MonoBehaviour
{
  public GameEvent OnZeroHealth = default;
  public float max = 3f;
  public float current { get => _current; }

  [SerializeField] private float _current = 3f;

  private void Awake()
  {
    _current = max;
  }

  public void TakeDamage(float amount)
  {
    _current -= amount;

    if (_current <= 0) OnZeroHealth?.Raise();
  }

  public void HealDamage(float amount)
  {
    _current = Mathf.Min(_current + amount, max);
  }

}
