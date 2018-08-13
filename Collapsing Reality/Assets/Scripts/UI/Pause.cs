using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject pauseMenu;
    public static bool Pausado;

    private void Start()
    {
        Resume();
    }

    void Update ()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) && Pausado)
            Resume();
        else if (Input.GetKeyDown(KeyCode.Escape))
            PauseGame();

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        Pausado = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Pausado = false;
    }
}
