using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{

    bool dead;

    void Start()
    {

    }


    void FixedUpdate()
    {
        if (transform.localScale.y < 2.9f)
            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(3, 3, 1), 0.1f);
        else
            dead = true;

        if(dead)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Mathf.MoveTowards(GetComponent<SpriteRenderer>().color.a, 0, 0.1f));
            Destroy(gameObject, 2);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "Player" && !dead)
            collision.transform.gameObject.GetComponent<Hp>().hp--;
    }

}
