using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryControllerLevel1 : MonoBehaviour
{
    private WaitForSeconds shortWait = new WaitForSeconds(1);
    [SerializeField]
    private ConsoleWindowController mainConsole;

    void Start()
    {
        OverridingSettings.currentLevel = 1;
        StartCoroutine(StartStory());
    }

    IEnumerator StartStory()
    {
        yield return shortWait;
        StartCoroutine(ConsoleController.AddLineOneLetterAtATime("Hello Cadet! You are equipped with a phaser set to stun. It isn't powerful but it's all you're licenced to use. Now Defeat those aliens and defend this base. Type OK to start.", ConsoleController.CommanderText));
        yield return shortWait;
        yield return shortWait;
        yield return shortWait;
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
