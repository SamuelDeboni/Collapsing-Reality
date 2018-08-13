using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patern1 : MonoBehaviour {

    public GameObject enemy;
	
	void Start ()
    {
        InvokeRepeating("SpawnEnemy", 0, 0.2f);
	}
	
	void SpawnEnemy()
    {
        GameObject e;
        e = Instantiate(enemy, transform.position+(new Vector3(Random.Range(-3,3), Random.Range(-3, 3),0)), Quaternion.identity);
        e.GetComponent<Enemy>().onlyAtackPlayer = true;
    }
}
