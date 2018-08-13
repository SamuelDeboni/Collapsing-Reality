using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour {

    public GameObject clickSound, hoverSound;

    public void MouseEnter()
    {
        Instantiate(hoverSound, transform.position, Quaternion.identity);
    }
   

    public void MouseDown()
    {
        Instantiate(clickSound, transform.position, Quaternion.identity);
    }


}
