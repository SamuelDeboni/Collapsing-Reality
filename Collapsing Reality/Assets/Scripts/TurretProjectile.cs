using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    public float vel;
    public Vector2 direction;
    public int damage;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * vel);
        var hit = Physics2D.Raycast(transform.position, direction, 0.05f);
        if (hit)
        {
            GameObject obj = hit.collider.gameObject;
            if (obj.GetComponent<Hp>() && obj.tag == "Enemy")
            {
                obj.GetComponent<Hp>().Damage(damage);
                Destroy(gameObject);
            }
        }
    }
}
