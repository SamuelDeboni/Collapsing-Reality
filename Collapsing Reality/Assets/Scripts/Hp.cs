using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// If a GameObject has this component, it can take damage and die
public class Hp : MonoBehaviour
{
    public bool hasSound;
    public GameObject sound;
    public int maxHp;
    public int hp;
    public float shakeCameraOnDeath;
    public GameObject deathEffects;
    public bool noDamage, isTheBoss;
    public bool dead;

    private void Start()
    {
        hp = maxHp;
    }

    public void Damage(int damage)
    {
        if (hasSound && damage > 0)
            Instantiate(sound, transform.position, transform.rotation);

        if (!noDamage)
            hp -= damage;
        hp = Mathf.Clamp(hp, 0, maxHp);

        if (isTheBoss && !noDamage)
        {
            Camera.main.GetComponent<CameraShake>().Shake(0.25f);
        }

        if (hp <= 0 && !dead)
            Die();
    }

    public void Die()
    {
        dead = true;

        if (deathEffects != null)
            Instantiate(deathEffects, transform.position, transform.rotation);
        Camera.main.GetComponent<CameraShake>().Shake(shakeCameraOnDeath);

        if (gameObject.tag == "Enemy")
            Score.score++;

        if (isTheBoss)
        {
            Utils.bossTime = false;
            Invoke("Credits", 3);
        }
        else
            Destroy(gameObject);
    }

    void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
