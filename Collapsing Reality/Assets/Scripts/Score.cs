using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI text;

    void Start()
    {

    }


    void Update()
    {
        text.text = "Enemies Killed: " + score.ToString();
    }
}
