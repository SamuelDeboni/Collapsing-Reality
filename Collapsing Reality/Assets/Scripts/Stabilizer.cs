using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabilizer : MonoBehaviour
{

    public float radius;
    public GameObject spotLight;
    float angle;
    public float radiusDecaySpeed;
    public int nTurrets = 0;
    public int maxTurrets = 6;

    public GameObject turret;
    float radiusMultiplier = 1;
    public List<GameObject> turrets;

    
    void Start()
    {
        AddTurret();
    }

    private void FixedUpdate()
    {
        //gameObject.GetComponent<Hp>().Damage(1);
    }

    void Update()
    {
        if (Utils.bossTime)
            radiusMultiplier = Mathf.MoveTowards(radiusMultiplier, 0.8f, 0.01f);
        else
            radiusMultiplier = Mathf.MoveTowards(radiusMultiplier, 1, 0.01f);


        radius = gameObject.GetComponent<Hp>().hp*0.005f * radiusMultiplier;
        spotLight.transform.localScale = new Vector3(1,1,1)*radius*2f;         
        int i = 0;
        foreach (GameObject t in turrets)
        {
            i++;
            Vector2 pos = Rect(1.5f, Time.time*20 + (360 / nTurrets) * i);
            t.transform.position = new Vector3(pos.x, pos.y, -3)+transform.position;
        }
        
        // 1600 hp => 6 turrets
        // 1400 hp => 5 turrets
        //        ...
        //  800 hp => 2 turrets
        //  600 hp => 1 turret
        int nTurretsTarget = Mathf.Clamp((gameObject.GetComponent<Hp>().hp - 400) / 200, 0, 6);

        if (nTurrets < nTurretsTarget)
            AddTurret();
        else if (nTurrets > nTurretsTarget)
            RemoveTurret();
    }

    Vector2 Rect(float magnitude, float angle)
    {
        return new Vector2(Mathf.Cos(angle * (Mathf.PI / 180)), Mathf.Sin(angle * (Mathf.PI / 180))) * magnitude;
    }

    void AddTurret()
    {
        nTurrets++;
        GameObject obj = Instantiate(turret, transform.position, Quaternion.identity, transform);
        obj.GetComponent<Turret>().parentStabilizer = gameObject;
        turrets.Add(obj);
        nTurrets = Mathf.Clamp(nTurrets, 1, maxTurrets);
    }

    void RemoveTurret()
    {
        nTurrets--;
        Destroy(turrets[turrets.Count-1]);
        turrets.RemoveAt(turrets.Count - 1);
        nTurrets = Mathf.Clamp(nTurrets, 1, maxTurrets);
    }
}
