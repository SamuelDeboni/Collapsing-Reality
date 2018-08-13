using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathEffect : MonoBehaviour {

    public GameObject energyOrb;

	void Start ()
    {
        Invoke("Destroy", 1);
        int q = Random.Range(2, 5);

        for (int i = 0; i <= q; i++)
            Instantiate(energyOrb, transform.position, transform.rotation);
	}

    void Destroy()
    {
        Destroy(gameObject);
    }

}
