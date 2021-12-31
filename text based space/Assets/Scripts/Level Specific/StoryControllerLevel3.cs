using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryControllerLevel3 : MonoBehaviour
{
    private WaitForSeconds shortWait = new WaitForSeconds(1);
    [SerializeField]
    private ConsoleWindowController mainConsole;

    void Start()
    {
        OverridingSettings.currentLevel = 3;
        StartCoroutine(StartStory());
    }

    IEnumerator StartStory()
    {
        yield return shortWait;
        StartCoroutine(ConsoleController.AddLineOneLetterAtATime("Good work! Defeat these guys and we'll move you on to a tougher foe.", ConsoleController.CommanderText));
        yield return shortWait;
        yield return shortWait;
        StartCoroutine(ConsoleController.AddLineOneLetterAtATime("OK this is getting unfair, here charge your phaser by typing in the cheat code '+'. It will only last a shot but just use it again when you're done. Try typing lots of + in a row to supercharge your phaser. The best part is + works with other cheats too so turn on PIERCE. ", ConsoleController.HackerText));
        yield return shortWait;
        yield return shortWait;
        yield return shortWait;
        yield return shortWait;
        yield return shortWait;
        StartCoroutine(ConsoleController.AddLineOneLetterAtATime("Type OK to start.", ConsoleController.playerText));
        ConsoleController.sentMessage = "";
        //
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

    //private void Update()
    //{
    //    Debug.Log(InputController.plusInCurrentWord);
    //}
}
