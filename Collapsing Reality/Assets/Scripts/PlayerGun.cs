using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public const int HP_HEALED_PER_ENERGY = 20;
    public GameObject sound;
    public int damage;

    Camera cam;
    public LayerMask mask;

    public GameObject laserParticles;

    void Start()
    {

    }

    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 50, mask);

        if (hit && Input.GetMouseButton(0) && hit.transform.gameObject.tag == "Enemy" && !Pause.Pausado)
            hit.transform.gameObject.GetComponent<Hp>().Damage(damage);
        else if (hit && Input.GetMouseButton(0) && hit.transform.gameObject.tag == "Stabilizer" && !Pause.Pausado)
        {
            if (hit.transform.gameObject.GetComponent<Hp>().hp <= 2000 && gameObject.GetComponent<PlayerControler>().energy > 0 && !Pause.Pausado)
            {
                hit.transform.gameObject.GetComponent<Hp>().Damage(-HP_HEALED_PER_ENERGY);
                gameObject.GetComponent<PlayerControler>().energy -= 1;
            }       
        }

        if (hit && !Pause.Pausado)
        {
            laserParticles.transform.localScale = new Vector3(1, Vector3.Distance(hit.point, transform.position), 1);
            laserParticles.transform.localPosition = new Vector3(0, Vector3.Distance(hit.point, transform.position), 0) * 0.5f;
        }
        else if(!Pause.Pausado)
        {
            laserParticles.transform.localScale = new Vector3(1, 50, 1);
            laserParticles.transform.localPosition = new Vector3(0, 25, 0);
        }

        gameObject.GetComponent<LineRenderer>().SetPosition(0, transform.position);
        if (hit && Input.GetMouseButton(0) && !Pause.Pausado)
        {
            gameObject.GetComponent<LineRenderer>().SetPosition(1, hit.point);
            sound.SetActive(true);
            laserParticles.SetActive(true);
            sound.GetComponent<AudioSource>().volume = 0.5f;
        }
        else if (Input.GetMouseButton(0) && !Pause.Pausado)
        {
            gameObject.GetComponent<LineRenderer>().SetPosition(1, transform.up * 50 + transform.position);
            sound.SetActive(true);
            laserParticles.SetActive(true);
            sound.GetComponent<AudioSource>().volume = 0.4f;
        }
        else if(!Pause.Pausado)
        {
            gameObject.GetComponent<LineRenderer>().SetPosition(1, transform.position);
            sound.SetActive(false);
            laserParticles.SetActive(false);
        }
    }
}
