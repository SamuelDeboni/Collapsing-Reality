using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyOrb : MonoBehaviour
{
    public const int ENERGY_DROPPED = 2;
    Vector2 initialVelocity;
    GameObject player;
    GameObject target;
    public GameObject sound;

    void Start()
    {
        initialVelocity = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
        gameObject.GetComponent<Rigidbody2D>().velocity = initialVelocity;
        Destroy(gameObject, 20);
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        if (target == null)
            target = FindTarget();

        if (Vector3.Distance(transform.position, player.transform.position) < 6f)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce((player.transform.position - transform.position).normalized * 50);
        }
        else if (Vector3.Distance(transform.position, target.transform.position) < 5f)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce((target.transform.position - transform.position).normalized * 5);
        }

        if (Vector3.Distance(transform.position, player.transform.position) < 1.5f)
        {
            player.GetComponent<PlayerControler>().energy += ENERGY_DROPPED;
            Instantiate(sound, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (Vector3.Distance(transform.position, target.transform.position) < 1.5f)
        {
            target.GetComponent<Hp>().Damage(-ENERGY_DROPPED * PlayerGun.HP_HEALED_PER_ENERGY);
            Destroy(gameObject);
        }
    }

    GameObject FindTarget()
    {
        GameObject[] stabilizers = GameObject.FindGameObjectsWithTag("Stabilizer");
        if (stabilizers.Length == 0)
            return GameObject.FindGameObjectWithTag("Player");

        GameObject closest = null;
        float closestDistance = float.MaxValue;
        foreach (GameObject stb in stabilizers)
        {
            float dist = Vector2.SqrMagnitude(stb.transform.position - transform.position);
            if (dist < closestDistance)
            {
                closest = stb;
                closestDistance = dist;
            }
        }

        return closest;
    }

}