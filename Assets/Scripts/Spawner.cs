using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
  [Tooltip("Spawn an entity every X seconds")]
  public float spawnRate = 1f;

  [Tooltip("List of entities to spawn. Each entity must have a RigidBody")]
  public Vector2 entityVelocityMinMax = new Vector2(0.5f, 2f);

  [Tooltip("Aim the entity at this transform when spawning")]
  public Transform spawnTransform = default;
  public List<GameObject> entities = default;

  [Header("Debug")]
  [SerializeField] private float spawnTimer = 0f;

  private void Update()
  {
    spawnTimer += Time.deltaTime;

    if (spawnTimer > spawnRate)
    {
      spawnTimer = 0f;
      SpawnEntity();
    }
  }

  private void SpawnEntity()
  {
    int idx = Random.Range(0, entities.Count);
    var entity = entities[idx];

    if (entity)
    {
      var obj = Instantiate(entity, gameObject.transform);
      float speed = Random.Range(entityVelocityMinMax.x, entityVelocityMinMax.y);
      Vector2 direction = (spawnTransform.position - obj.transform.position).normalized;
      obj.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
  }
}
