using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryControllerLevel8 : MonoBehaviour
{
    private WaitForSeconds shortWait = new WaitForSeconds(1);
    [SerializeField]
    private ConsoleWindowController mainConsole;

    void Start()
    {
        OverridingSettings.currentLevel = 8;
        StartCoroutine(StartStory());
    }

    IEnumerator StartStory()
    {
        yield return shortWait;
        StartCoroutine(ConsoleController.AddLineOneLetterAtATime("You think I wouldn't catch you using fire! Fine fight these guys who love the stuff.", ConsoleController.CommanderText));
        yield return shortWait;
        yield return shortWait;
        StartCoroutine(ConsoleController.AddLineOneLetterAtATime("Type OK to start.", ConsoleController.playerText));
        ConsoleController.sentMessage = "";
        //Debug.Log(ConsoleController.sentMessage);
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
