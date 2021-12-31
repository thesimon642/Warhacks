using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && OverridingSettings.allowPauseMenuToFunction)
        {
            Quit();
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
