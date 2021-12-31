using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryControllerLevel2 : MonoBehaviour
{
    private WaitForSeconds shortWait = new WaitForSeconds(1);
    [SerializeField]
    private ConsoleWindowController mainConsole;

    void Start()
    {
        OverridingSettings.currentLevel = 2;
        StartCoroutine(StartStory());
    }

    IEnumerator StartStory()
    {
        yield return shortWait;
        StartCoroutine(ConsoleController.AddLineOneLetterAtATime("You did well Cadet. Now to face a real wave.", ConsoleController.CommanderText));
        yield return shortWait;
        yield return shortWait;
        StartCoroutine(ConsoleController.AddLineOneLetterAtATime("This hardly seems fair. Here try the cheat code PIERCE to set your phaser to pierce right through them and hit all enemies they're touching. Your Hacker friend.", ConsoleController.HackerText));
        yield return shortWait;
        yield return shortWait;
        yield return shortWait;
        StartCoroutine(ConsoleController.AddLineOneLetterAtATime("Type OK to start.", ConsoleController.playerText));
        ConsoleController.sentMessage = "";
        //
        //
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
