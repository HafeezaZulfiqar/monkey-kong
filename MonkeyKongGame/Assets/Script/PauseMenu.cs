using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject instruction;
    // Start is called before the first frame update
    public void pause ()
    {
        pauseMenu.SetActive(true);
        instruction.SetActive(false);
        Time.timeScale = 0;
    }
    public void Resume ()
    {
        pauseMenu.SetActive(false);
        instruction.SetActive(false);
        Time.timeScale = 1;
    }
 //   public void Home (int sceneId)
   // {
     //   Time.timeScale = 1;
       // SceneManager.LoadScene(sceneId);
   // }

    public void Home()
    {
        pauseMenu.SetActive(false);
        instruction.SetActive(true);
        Time.timeScale = 1;
    }
    public void back()
    {
        pauseMenu.SetActive(true);
        instruction.SetActive(false);
        Time.timeScale = 1;
    }
}
