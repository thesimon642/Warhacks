using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseChanger : MonoBehaviour
{
    [SerializeField]
    private Texture2D crosshair;
    [SerializeField]
    private Transform topBorder;
    [SerializeField]
    private Camera camera1;
    [SerializeField]
    private ConsoleWindowController mainConsole;

    private void Update()
    {
        //set to crosshair if on the battlefield with console up
        if (mainConsole.posisiondown || camera1.ScreenToWorldPoint(Input.mousePosition).y > topBorder.position.y || PauseController.paused)
        { Cursor.SetCursor(null, Vector2.zero, 0); }
        else
        { Cursor.SetCursor(crosshair, new Vector2(crosshair.width/2,crosshair.height/2), 0); }
    }
    
}
