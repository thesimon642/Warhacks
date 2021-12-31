using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInputs : MonoBehaviour
{
    [SerializeField]
    public string sceneTopWave;
    [SerializeField]
    public string sceneMiddleWave;
    [SerializeField]
    public string sceneBottomWave;
    [SerializeField]
    public bool[] availableWords = new bool[5];
}
