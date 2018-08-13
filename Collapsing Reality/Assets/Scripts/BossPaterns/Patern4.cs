using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patern4 : MonoBehaviour {

	void Update ()
    {
        transform.Rotate(0, 0, Time.deltaTime * 90);
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "Player")
            collision.transform.gameObject.GetComponent<Hp>().Damage(1);

    }
}
