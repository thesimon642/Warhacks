using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverridingSettings : MonoBehaviour
{
    public static OverridingSettings instance;
   
    public static bool musicUnmuted = true;
    public static bool sfxUnmuted = true;
    public static bool fullscreenOn = true;
    //public static bool pasteOff = false;

    public static bool allowPauseMenuToFunction = true;
    [SerializeField]
    private AudioSource musicPlayerSerial;
    public static AudioSource musicPlayer;
    //cosmetic settings to keep the menu effect consistent
    public static int menuTarget = -100;
    public static float menuCameraZ = -500;

    public static bool endlessUnlocked = false;

    public static int lastLevelBeaten = 0;
    public static bool inFreeplay = false;
    public static int continueLevelForWinScreen;
    public static int currentLevel;

    //controls if script needs to contain the word but resets after each fire (false) or toggles between all 4 fire modes (true)
    public static bool newMode = true;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        { 
            instance = this;
            musicPlayer = musicPlayerSerial;
            Application.targetFrameRate = 60;
        }
        else
        { Destroy(this.gameObject); }
    }
}
