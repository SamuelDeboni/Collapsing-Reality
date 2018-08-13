using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericDestroy : MonoBehaviour {

    public float t;

	void Start ()
    {
        Destroy(gameObject, t);
	}
	

}
