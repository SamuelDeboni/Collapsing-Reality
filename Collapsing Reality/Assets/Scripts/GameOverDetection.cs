
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverDetection : MonoBehaviour {


	void Start ()
    {
        InvokeRepeating("GameOverCheck", 0, 1);
	}
	
    void GameOverCheck()
    {
        GameObject stabilizer = null;
        stabilizer = Utils.FindClosestTo(transform.position, "Stabilizer");

        if (stabilizer == null && GameObject.FindGameObjectWithTag("Player") == null)
            Debug.Log("GameOver");
    }

    void GameOver()
    {
        SceneManager.LoadScene("Main Menu");//provisory
    }

}
