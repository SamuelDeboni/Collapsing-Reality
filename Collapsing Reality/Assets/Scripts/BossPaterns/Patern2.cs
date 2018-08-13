using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patern2 : MonoBehaviour
{

    public GameObject enemy;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject e;

        for (int j = 0; j < 2; j++)
            for (int i = 0; i < 5; i++)
            {
                e = Instantiate(enemy, player.transform.position + new Vector3(11, -i * 2 + 6f), Quaternion.identity);
                e.GetComponent<Enemy>().notAtack = true;
                e.transform.up = Vector2.left;
                Destroy(e, 10);

                e = Instantiate(enemy, player.transform.position + new Vector3(i * 2 - 6f, 11), Quaternion.identity);
                e.GetComponent<Enemy>().notAtack = true;
                e.transform.up = Vector2.down;
                Destroy(e, 10);

                e = Instantiate(enemy, player.transform.position + new Vector3(-11, i * 2 - 5f), Quaternion.identity);
                e.GetComponent<Enemy>().notAtack = true;
                e.transform.up = Vector2.right;
                Destroy(e, 10);

                e = Instantiate(enemy, player.transform.position + new Vector3(-i * 2 + 5f, -11), Quaternion.identity);
                e.GetComponent<Enemy>().notAtack = true;
                e.transform.up = Vector2.up;
                Destroy(e, 10);

                yield return new WaitForSeconds(0.5f);
            }


    }
}
