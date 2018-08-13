using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject parentStabilizer;
    public int energyLostPerShot;
    public GameObject target;
    public float attackDelay;
    public GameObject projectilePrefab;

    private void Start()
    {
        StartCoroutine(Attack());
    }
    
    IEnumerator Attack()
    {
        for(; ; )
        {
            target = Utils.FindClosestTo(transform.position, "Enemy");
            if (target != null && Vector2.SqrMagnitude(target.transform.position - transform.position) < 100f && !target.GetComponent<Hp>().isTheBoss)
            {
                var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
                projectile.GetComponent<TurretProjectile>().direction = (target.transform.position - transform.position).normalized;
                parentStabilizer.GetComponent<Hp>().Damage(energyLostPerShot);
                // Zero out z coordinate
                projectile.transform.position = new Vector3(projectile.transform.position.x, projectile.transform.position.y, 0f);
            }

            yield return new WaitForSeconds(attackDelay);
        }
    }

}
