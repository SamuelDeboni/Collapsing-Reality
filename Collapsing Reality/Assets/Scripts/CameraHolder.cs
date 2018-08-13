using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour {

    Transform playerTransform;
    public float acel;
    public int cameraSize;

    void Start ()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        InvokeRepeating("SearchStabilizers", 0, 0.2f);
	}
	

	void Update ()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, playerTransform.position, acel);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, cameraSize, 0.2f);
    }

    void SearchStabilizers()
    {
        GameObject[] stabilizer = GameObject.FindGameObjectsWithTag("Stabilizer");

        cameraSize =  stabilizer.Length + 20;
        cameraSize = Mathf.Clamp(cameraSize, 20, 30);      
    }
}
