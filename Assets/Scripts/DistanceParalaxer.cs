using UnityEngine;

public class DistanceParalaxer : MonoBehaviour
{
  public Attribute distance;
  public Vector2 target;
  public float totalAttributeDistance = 100f;

  [Header("Debug")]
  [SerializeField] private float completePct = 0f;

  private Vector2 start;

  private void Start()
  {
    start = new Vector2(transform.position.x, transform.position.y);
    transform.position = start;
  }

  private void Update()
  {
    completePct = distance.value / totalAttributeDistance;
    transform.position = Vector2.Lerp(start, target, completePct);
  }
}
