using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryControllerLevel9 : MonoBehaviour
{
    private WaitForSeconds shortWait = new WaitForSeconds(1);
    [SerializeField]
    private ConsoleWindowController mainConsole;

    void Start()
    {
        OverridingSettings.currentLevel = 9;
        StartCoroutine(StartStory());
    }

    IEnumerator StartStory()
    {
        yield return shortWait;
        StartCoroutine(ConsoleController.AddLineOneLetterAtATime("Prehaps I underestimated you, here fight this for that big promotion.", ConsoleController.CommanderText));
        yield return shortWait;
        yield return shortWait;
        StartCoroutine(ConsoleController.AddLineOneLetterAtATime("I've discovered a new cheat code. RAPID will replace your current mode but just hold down the fire button and watch the magic happen.", ConsoleController.HackerText));
        yield return shortWait;
        yield return shortWait;
        yield return shortWait;
        StartCoroutine(ConsoleController.AddLineOneLetterAtATime("Type OK to start.", ConsoleController.playerText));
        ConsoleController.sentMessage = "";
        //.Log(ConsoleController.sentMessage);
        while (ConsoleController.sentMessage.ToLower() != "ok")
        { yield return null; }
        StartCoroutine(ConsoleController.AddLineOneLetterAtATime("Battle Commencing", ConsoleController.playerText));
        yield return shortWait;
        WaveSender.StartSceneWaves();
        //if console windown is down and not moving, send it up for the fist wave
        if (mainConsole.posisiondown && !mainConsole.moving)
        { mainConsole.MoveWindow(); }
    }
}
