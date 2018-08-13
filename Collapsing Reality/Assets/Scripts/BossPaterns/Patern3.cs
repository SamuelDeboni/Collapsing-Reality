using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patern3 : MonoBehaviour {

    public GameObject voidP;

    void Start()
    {
        InvokeRepeating("SpawnVoid", 0, 0.5f);
    }

    void SpawnVoid()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject e;
        e = Instantiate(voidP, player.transform.position + (new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0)), Quaternion.identity);
        e.GetComponent<Enemy>().onlyAtackPlayer = true;
    }
}
