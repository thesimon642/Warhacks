using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Navigator : MonoBehaviour
{
    private string continueLevel;
    private bool continueUnavailable;
    [SerializeField]
    private TextMeshProUGUI ContinueButton;
    [SerializeField]
    private GameObject settingsMenu;


    private void Start()
    {
        continueUnavailable = false;
        OverridingSettings.allowPauseMenuToFunction = true;

        if (SceneManager.GetActiveScene().name == "Win Screen")
        {
            if (OverridingSettings.continueLevelForWinScreen == 0 || OverridingSettings.continueLevelForWinScreen == 10)
            {
                continueUnavailable = true;
                ContinueButton.text = "Continue Unavailable";

            }
            else
            {
                continueUnavailable = false;
                continueLevel = (OverridingSettings.continueLevelForWinScreen).ToString();
                ContinueButton.text = "Continue: Level " + continueLevel;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            if (OverridingSettings.lastLevelBeaten == 0 || OverridingSettings.lastLevelBeaten == 9)
            {
                continueUnavailable = true;

                ContinueButton.text = "Continue Unavailable";

            }
            else
            {
                continueUnavailable = false;
                continueLevel = (OverridingSettings.lastLevelBeaten + 1).ToString();
                ContinueButton.text = "Continue: Level " + continueLevel;
            }
        }
        if (SceneManager.GetActiveScene().name == "Lose Screen")
        {
            ContinueButton.text = "Try Again";
        }

        if (SceneManager.GetActiveScene().name == "Freeplay")
        { OverridingSettings.inFreeplay = true; }
        //create and destroy to initialize settings
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            GameObject tempSettings = Instantiate(settingsMenu);
            Destroy(tempSettings);
        }
    }
    public void NewGame()
    {
        if (OverridingSettings.allowPauseMenuToFunction)
        {
            OverridingSettings.lastLevelBeaten = 0;
            OverridingSettings.inFreeplay = false;
            SceneManager.LoadScene("Level 1");
        }
    }
    public void Continue()
    {
        if (OverridingSettings.allowPauseMenuToFunction && !continueUnavailable)
        {
            OverridingSettings.inFreeplay = false;
            SceneManager.LoadScene("Level " + continueLevel);
        }
    }
    public void Settings()
    {
        if (OverridingSettings.allowPauseMenuToFunction)
        {
            OverridingSettings.allowPauseMenuToFunction = false;
            GameObject mySettingMenu = Instantiate(settingsMenu, new Vector3(0, 0, 1), Quaternion.identity);
            mySettingMenu.transform.SetParent(Camera.main.gameObject.transform);
            mySettingMenu.transform.localScale = new Vector2(30, 30);
            //SceneManager.LoadScene("Settings");
        }
    }
    public void Freeplay()
    {
        if (OverridingSettings.allowPauseMenuToFunction)
        {
            SceneManager.LoadScene("Freeplay");
        }
    }
    public void Endless()
    {
        if (OverridingSettings.allowPauseMenuToFunction && OverridingSettings.endlessUnlocked)
        {
            SceneManager.LoadScene("Endless");
        }
    }
    public void Credits()
    {
        if (OverridingSettings.allowPauseMenuToFunction)
        {
            SceneManager.LoadScene("Credits");
        }
    }
    public void ReturnToMainMenu()
    {
        if (OverridingSettings.allowPauseMenuToFunction)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Main Menu" && Input.GetKeyDown(KeyCode.Escape) && !OverridingSettings.allowPauseMenuToFunction)
        {
            ReturnToMainMenu();
        }
    }
    public void WinContinueButton()
    {
        if (!continueUnavailable)
        {
            SceneManager.LoadScene("Level " + OverridingSettings.continueLevelForWinScreen.ToString());
        }
    }

}
