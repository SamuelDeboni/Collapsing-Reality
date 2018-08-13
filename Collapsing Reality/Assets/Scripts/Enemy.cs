using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    Vector2 vel;
    public float maxVel, acel;
    Rigidbody2D rb;
    public int damage;
    public float attackDelay;
    public bool onlyAtackPlayer,notAtack;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Attack());
    }

    void Update()
    {
        if (target == null && !notAtack)
        {
            target = Utils.FindClosestTo(transform.position, "Stabilizer");
            if (target == null || onlyAtackPlayer) // If target is still null, no stabilizer was found
                target = GameObject.FindGameObjectWithTag("Player"); // so we attack the player
        }            
        else if(!notAtack)
        {
            transform.up = ((Vector2)target.transform.position - (Vector2)transform.position).normalized;

            vel = Vector2.MoveTowards(vel, transform.up * maxVel, acel);
            rb.velocity = vel;
        }
        else
        {
            GetComponent<CircleCollider2D>().isTrigger = true;
            vel = Vector2.MoveTowards(vel, transform.up * maxVel, acel);
            rb.velocity = vel;
        }
    }

    IEnumerator Attack()
    {
        for (; ;)
        {
            var hit = Physics2D.Raycast(transform.position + transform.up * 0.51f, transform.up, 0.1f);
            if (hit)
            {
                GameObject hitObj = hit.collider.gameObject;

                if (hitObj.GetComponent<Hp>())
                {
                    if (hitObj.tag != "Enemy") // No friendly fire
                        hitObj.GetComponent<Hp>().Damage(damage);

                    if (hitObj.tag != "Enemy" && notAtack) // No friendly fire
                        hitObj.GetComponent<Hp>().Damage(damage*2);
                }
            }

            yield return new WaitForSeconds(attackDelay);
        }
    }
}
