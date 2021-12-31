using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    [SerializeField]
    private Slider progressBar;
    private float progressPercentage;
    public static float waveSize;
    public static float progress;

    private void Start()
    {
        waveSize = 1f;
        progress = 0f;
    }
    private void Update()
    {
        progressPercentage = progress / waveSize;
        progressBar.value = progressPercentage;
    }
}
