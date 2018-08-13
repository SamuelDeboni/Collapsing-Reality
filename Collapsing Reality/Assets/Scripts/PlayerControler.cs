using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    Vector2 tUp;
    Vector2 playerVelocity;
    public float maxVel, acel;
    Rigidbody2D rb;
    public float energy;
    public GameObject stabilizer;
    public AudioSource music;
    public AudioClip bossMusic;
    bool changedMusic;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Pause.Pausado = false;
        InvokeRepeating("LifeRegen", 0, 1);
    }


    void Update()
    {
        if (!Pause.Pausado)
            tUp = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        tUp.Normalize();
        transform.up = tUp;

        energy = Mathf.Clamp(energy, 0, 201);

        playerVelocity = Vector2.MoveTowards(playerVelocity, new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * maxVel, acel);
        rb.velocity = playerVelocity;

        if (Input.GetKeyDown(KeyCode.Space))
            PlaceStabilizer();

        if (Utils.bossTime && !changedMusic)
        {
            changedMusic = true;
            music.clip = bossMusic;
            music.Play();
        }

    }

    void LifeRegen()
    {
        GameObject closestStabilizer = Utils.FindClosestTo(transform.position, "Stabilizer");
        if (Vector3.Distance(closestStabilizer.transform.position, transform.position) >
            closestStabilizer.GetComponent<Stabilizer>().radius + 1)
        {
            gameObject.GetComponent<Hp>().Damage(10);
        }
        else
        {
            gameObject.GetComponent<Hp>().Damage(-2);
        }
    }

    void PlaceStabilizer()
    {
        if (energy > 100 && Vector3.Distance(Utils.FindClosestTo(transform.position,"Stabilizer").transform.position,transform.position) > 2)
        {
            Instantiate(stabilizer, transform.position - transform.up * 0.2f, Quaternion.identity);
            energy -= 100;
        }
    }
}
