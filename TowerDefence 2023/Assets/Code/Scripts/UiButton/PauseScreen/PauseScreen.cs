using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject PauseScreenUI;
      void Update()
      {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
                {
                    Pause();
                }
        }
      }

      public void Resume()
      {
          PauseScreenUI.SetActive(false);
          Time.timeScale = 1f;
          GameIsPaused = false;
      }

     void Pause()
     {
        PauseScreenUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
     }
}
