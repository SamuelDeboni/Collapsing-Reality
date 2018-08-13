using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMen : MonoBehaviour {

    public void GoToScene(string scene)
    {
        if(scene == "SampleScene")
        {
            Score.score = 0;
        }

        SceneManager.LoadScene(scene);
    }
	
    public void Quit()
    {
        Application.Quit();
    }
}
