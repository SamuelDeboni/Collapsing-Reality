using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

    public Sprite closedSprite, openedSprite;
    bool isClosed = true;
    Hp hpScript;
    GameObject patern;

    GameObject lifeBar;

    public GameObject patern1,patern2,patern3,patern4;

	void Start ()
    {
        hpScript = gameObject.GetComponent<Hp>();
        Utils.bossTime = true;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        lifeBar = GameObject.Find("@BossLife");
        StartCoroutine(Paterns());
        lifeBar.transform.localPosition = new Vector3(0,280,0);

        if(Vector3.Distance(transform.position,Utils.FindClosestTo(transform.position,"Stabilizer").transform.position) < 2 || 
        Vector3.Distance(transform.position, Utils.FindClosestTo(transform.position, "Stabilizer").transform.position) > 10)
            transform.position = -(Utils.FindClosestTo(transform.position, "Stabilizer").transform.position - transform.position).normalized*4;
        


    }
	

	void FixedUpdate ()
    {

        lifeBar.GetComponent<Slider>().value = hpScript.hp;
        if (gameObject.GetComponent<SpriteRenderer>().color != new Color(1, 1, 1, 1))
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Mathf.MoveTowards(gameObject.GetComponent<SpriteRenderer>().color.a,1,0.02f));

        if (isClosed)
            gameObject.GetComponent<SpriteRenderer>().sprite = closedSprite;
        else
            gameObject.GetComponent<SpriteRenderer>().sprite = openedSprite;

        if (hpScript.dead)
            Destroy(patern);

        if (hpScript.hp <= 0)
            Destroy(gameObject.GetComponent<SpriteRenderer>());

        Camera.main.GetComponent<CameraShake>().Shake(0.05f);
    }


    IEnumerator Paterns()
    {
        for (; ; )
        {

            hpScript.noDamage = true;
            isClosed = true;
            int r;


            yield return new WaitForSeconds(3);

            for (int i = 0; i < 2; i++)
            {
                yield return new WaitForSeconds(5);

                r = Random.Range(0, 10);
                if (r > 5)
                    patern = Instantiate(patern1, transform.position, transform.rotation, transform);
                else
                    patern = Instantiate(patern2, transform.position, transform.rotation, transform);

                yield return new WaitForSeconds(10);
                Destroy(patern);
            }


            yield return new WaitForSeconds(5);
            hpScript.noDamage = false;
            isClosed = false;
            Camera.main.GetComponent<CameraShake>().Shake(5);

            for (int i = 0; i < 4; i++)
            {
                yield return new WaitForSeconds(2);

                r = Random.Range(0, 10);
                if (r > 5)
                    patern = Instantiate(patern3, transform.position, transform.rotation, transform);
                else
                    patern = Instantiate(patern4, transform.position, transform.rotation, transform);

                yield return new WaitForSeconds(10);
                Destroy(patern);
            }
        }
    }
}
