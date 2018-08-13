using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour {

    float status;
    public int statusIndex;
    GameObject player;

	void Start ()
    {

        player = GameObject.FindGameObjectWithTag("Player");
	}
	

	void Update ()
    {
        if (player != null)
        {

            if (statusIndex == 0)
                gameObject.GetComponent<Slider>().value = Mathf.MoveTowards(gameObject.GetComponent<Slider>().value, player.GetComponent<Hp>().hp, 1f);
            else if (statusIndex == 1)
                gameObject.GetComponent<Slider>().value = Mathf.MoveTowards(gameObject.GetComponent<Slider>().value, player.GetComponent<PlayerControler>().energy, 4f);

        }
    }
}
