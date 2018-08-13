using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {

    public GameObject boss;

	void Update ()
    {
		if(Score.score >= 1500)
        {
            SpawnBoss();
            Destroy(gameObject);
        }
            
	}

    void SpawnBoss()
    {
        GameObject[] stabilizers = GameObject.FindGameObjectsWithTag("Stabilizer");
        Vector3 pos = new Vector3(0,0,0);

        foreach(GameObject s in stabilizers)
        {
            pos += s.transform.position;
        }

        pos /= stabilizers.Length;

        Camera.main.GetComponent<CameraShake>().Shake(10);
        Instantiate(boss, pos, Quaternion.identity);
    }
}
