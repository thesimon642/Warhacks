using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyObjectSerial = new GameObject[1];
    public static GameObject[] enemyObject;
    [SerializeField]
    private AudioSource explodeSoundSerial;
    public static AudioSource explodeSound;

    public static bool plusAvailable;
    public static bool pierceAvailable;
    public static bool stunAvailable;
    public static bool fireAvailable;
    public static bool rapidAvailable;
    //[SerializeField]
    //private bool[] availableWords = new bool[5];
    [SerializeField]
    private SceneInputs mainInputs;
    [SerializeField]
    private ConsoleWindowController mainConsoleSerial;
    public static ConsoleWindowController mainConsole;
    private void Start()
    {
        enemyObject = enemyObjectSerial;
        explodeSound = explodeSoundSerial;

        plusAvailable   = mainInputs.availableWords[0];
        pierceAvailable = mainInputs.availableWords[1];
        stunAvailable   = mainInputs.availableWords[2];
        fireAvailable   = mainInputs.availableWords[3];
        rapidAvailable  = mainInputs.availableWords[4];
        mainConsole = mainConsoleSerial;
    }

}
