using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    const float SPAWN_DISTANCE = 10f;
    const int MAX_ENEMIES = 200;

    // Spawn rate increases as a percentage from `enemiesPerSecondBase`
    const float SPAWN_RATE_INCREASE = 0.3f;
    const float TIME_BETWEEN_SPAWN_RATE_INCREASES = 20f;

    public GameObject enemyPrefab;
    public float enemiesPerSecond;
    float enemiesPerSecondBase; // The original, base-level for `enemiesPerSecond`
       
    void Start()
    {
        enemiesPerSecondBase = enemiesPerSecond;
        StartCoroutine(Spawn());
        StartCoroutine(IncreaseSpawnRate());
    }

    IEnumerator Spawn()
    {
        while (!Utils.bossTime)
        {
            // We don't want too many enemies impacting performance
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < MAX_ENEMIES)
            {
                float ang = Random.Range(0.0f, 2 * Mathf.PI);
                Vector2 pos = 100f * new Vector2(Mathf.Cos(ang), Mathf.Sin(ang));
                GameObject target = Utils.FindClosestTo(pos, "Stabilizer");
                if (target == null)
                    target = GameObject.FindGameObjectWithTag("Player");

                // Brings the enemy closer to its target. The distance is defined by `SPAWN_DISTANCE`
                pos = (Vector2)target.transform.position + SPAWN_DISTANCE * (pos - (Vector2)target.transform.position).normalized;

                var spawned = Instantiate(enemyPrefab, pos, Quaternion.identity);
                spawned.transform.parent = transform;
                spawned.GetComponent<Enemy>().target = target;
            }           

            float delay = 1.0f / Mathf.Clamp(enemiesPerSecond, 0.00001f, 100000f);
            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator IncreaseSpawnRate()
    {
        while (!Utils.bossTime)
        {
            enemiesPerSecond += SPAWN_RATE_INCREASE * enemiesPerSecondBase;
            yield return new WaitForSeconds(TIME_BETWEEN_SPAWN_RATE_INCREASES);
        }
    }
}
