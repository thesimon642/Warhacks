using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSender : MonoBehaviour
{
    [SerializeField]
    private WaveController topWaveSerial;
    private static WaveController topWave;
    [SerializeField]
    private WaveController midWaveSerial;
    private static WaveController midWave;
    [SerializeField]
    private WaveController botWaveSerial;
    private static WaveController botWave;

    private static string staticsceneTopWave;
    private static string staticsceneMiddleWave;
    private static string staticsceneBottomWave;

    [SerializeField]
    private SceneInputs mainInputs;
    private void Start()
    {
        topWave = topWaveSerial;
        midWave = midWaveSerial;
        botWave = botWaveSerial;

        staticsceneTopWave = mainInputs.sceneTopWave;
        staticsceneMiddleWave = mainInputs.sceneMiddleWave;
        staticsceneBottomWave = mainInputs.sceneBottomWave;

    }

    public static void Send(string waveForm, int spawner)
    {
        switch (spawner)
        {
            case 1:
                topWave.Send(waveForm);
                break;
            case 2:
                midWave.Send(waveForm);
                break;
            case 3:
                botWave.Send(waveForm);
                break;
        }
    }

    public static void StartSceneWaves()
    {
        ProgressBarController.waveSize = staticsceneBottomWave.Length + staticsceneMiddleWave.Length + staticsceneTopWave.Length;
        Send(staticsceneTopWave, 1);
        Send(staticsceneMiddleWave, 2);
        Send(staticsceneBottomWave, 3);
    }
}
