using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PauseController : MonoBehaviour
{
    public static bool paused;
    [SerializeField]
    private ConsoleWindowController pauseWindow;
    private GameObject[] allGameObjects;
    [SerializeField]
    private GameObject mainConsoleHitbox;
    [SerializeField]
    private TextMeshPro availableCodes;
    [SerializeField]
    private TMP_InputField consoleInput;
    [SerializeField]
    private GameObject settingsWindow;
    [SerializeField]
    private GameObject areYouSureWindow;
    public static PauseController instance;

    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause(true);
        }
    }

    private void OnMouseDown()
    {
        if (OverridingSettings.allowPauseMenuToFunction)
        { PauseUnpause(true); }
    }

    public void PauseUnpause(bool move)
    {
        if (OverridingSettings.allowPauseMenuToFunction)
        {
            if (move)
            { pauseWindow.MoveWindow(); }

            paused = !paused;
            SetAvailableCodes();
            //paused now is true if it is paused
            //if (paused)
            // { Pause(); }
            //else
            // { UnPause(); }

            //freezes/unfreezes the timescale
            Time.timeScale = paused == true ? 0 : 1f;
            //enable/disable all enemy hitboxes
            allGameObjects = GameObject.FindGameObjectsWithTag("EnemyHitbox");
            //disable all enemy colliders
            foreach (GameObject enemy in allGameObjects)
            { enemy.GetComponent<BoxCollider2D>().enabled = !paused; }
            //disable main console colider
            mainConsoleHitbox.GetComponent<BoxCollider2D>().enabled = !paused;
            //disable the input box
            consoleInput.enabled = !paused;
        }
    }


    public void ReturnToMainMenu()
    {
        if (OverridingSettings.allowPauseMenuToFunction)
        {
            OverridingSettings.allowPauseMenuToFunction = false;
            Instantiate(areYouSureWindow, Vector3.zero, Quaternion.identity);
        }
    }
    private void SetAvailableCodes()
    {
        //set available codes text on pause menu
        availableCodes.text = "";
        if (PrefabHolder.plusAvailable)
        { availableCodes.text = "Available cheat codes: +"; }
        else
        {
            availableCodes.text = "No cheat codes unlocked.";
            return;
        }
        if (PrefabHolder.pierceAvailable)
        { availableCodes.text += ", Pierce"; }
        if (PrefabHolder.stunAvailable)
        { availableCodes.text += ", Stun"; }
        if (PrefabHolder.fireAvailable)
        { availableCodes.text += ", Fire"; }
        if (PrefabHolder.rapidAvailable)
        { availableCodes.text += ", Rapid"; }
    }

    public void ActivateSettings()
    {
        OverridingSettings.allowPauseMenuToFunction = false;
        Instantiate(settingsWindow, Vector3.zero,Quaternion.identity);
    }
}
