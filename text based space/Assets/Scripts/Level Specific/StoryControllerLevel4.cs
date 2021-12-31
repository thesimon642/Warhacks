using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryControllerLevel4 : MonoBehaviour
{
    private WaitForSeconds shortWait = new WaitForSeconds(1);
    [SerializeField]
    private ConsoleWindowController mainConsole;

    void Start()
    {
        OverridingSettings.currentLevel = 4;
        StartCoroutine(StartStory());
    }

    IEnumerator StartStory()
    {
        yield return shortWait;
        StartCoroutine(ConsoleController.AddLineOneLetterAtATime("OK now you can try these guys. They're completely immune to our charged weapons but that shouldn't be a problem for you, you took on much stronger enemies without even having a gun that can charge.", ConsoleController.CommanderText));
        yield return shortWait;
        yield return shortWait;
        yield return shortWait;
        yield return shortWait;
        StartCoroutine(ConsoleController.AddLineOneLetterAtATime("Looks like + is out... better try STUN. It will turn off PIERCE though so be careful.",ConsoleController.HackerText));
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
