using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreYouSureWindow : MonoBehaviour
{
    private PauseController pauseMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { ReturnToGame(); }
    }
    private void Start()
    {
        pauseMenu = PauseController.instance;
    }
    public void ReturnToGame()
    {
        OverridingSettings.allowPauseMenuToFunction = true;
        Destroy(this.gameObject);
    }
    public void ReturnToMainMenu()
    {
        OverridingSettings.allowPauseMenuToFunction = true;
        //Time.timeScale = 1;
        pauseMenu.PauseUnpause(false);
        SceneManager.LoadScene("Main Menu");
    }
}
