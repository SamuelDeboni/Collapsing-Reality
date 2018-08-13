using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float dropoff;
    public float maxShake;

    Vector3 startPosition;
    float currentShake;

    void Start()
    {
        startPosition = transform.localPosition;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            Shake(1);
    }

    void FixedUpdate()
    {
        if (currentShake > 0.1f)
        {
            transform.localPosition = startPosition + (new Vector3(Random.insideUnitCircle.x, Random.insideUnitCircle.y, 0)) * currentShake;
            currentShake /= dropoff;
        }
        else
        {
            currentShake = 0f;
            transform.localPosition = startPosition;
        }
    }

    public void Shake(float strength)
    {
        currentShake += strength;
        currentShake = Mathf.Clamp(strength, 0, maxShake);
    }
}