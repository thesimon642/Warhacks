using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class WaveCounter : MonoBehaviour
{
    public static int completedSpawners;
    public static int spawnedEnemies;
    public static int defeatedEnemies;

    public static bool win = false;


    void Start()
    {
        win = false;
        completedSpawners = 0;
        spawnedEnemies = 0;
        defeatedEnemies = 0;
        OverridingSettings.continueLevelForWinScreen = OverridingSettings.currentLevel;
    }
    private void Update()
    {
        if (completedSpawners >= 3 && spawnedEnemies == defeatedEnemies && !ForcefieldController.lose)
        {
            win = true;
            if (OverridingSettings.inFreeplay)
            { 
                OverridingSettings.continueLevelForWinScreen += 1; 
            }
            else
            {
                OverridingSettings.lastLevelBeaten = OverridingSettings.currentLevel;
                OverridingSettings.continueLevelForWinScreen = OverridingSettings.lastLevelBeaten + 1;
            }
            SceneManager.LoadScene("Win Screen");
        }
        
    }



}
