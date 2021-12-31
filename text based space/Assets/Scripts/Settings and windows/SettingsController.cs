using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI musicButton;
    [SerializeField]
    private TextMeshProUGUI sfxButton;
    [SerializeField]
    private TextMeshProUGUI fullscreenButton;


    private void Start()
    {
        FullscreenSetText();
        SFXSetText();
        MusicSetText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { ReturnToGame(); }
    }
    public void ReturnToGame()
    {
        OverridingSettings.allowPauseMenuToFunction = true;
        Destroy(this.gameObject);
    }
    public void FullscreenSet()
    {
        OverridingSettings.fullscreenOn = !OverridingSettings.fullscreenOn;
        Screen.fullScreen = OverridingSettings.fullscreenOn;
        FullscreenSetText();
    }

    public void SFXSet()
    {
        OverridingSettings.sfxUnmuted = !OverridingSettings.sfxUnmuted;
        if (OverridingSettings.sfxUnmuted)
        {
            sfxButton.text = "SFX: Unmuted";
        }
        else
        {
            sfxButton.text = "SFX: Muted";
        }
        SFXSetText();
    }

    public void MusicSet()
    {
        OverridingSettings.musicUnmuted = !OverridingSettings.musicUnmuted;
        OverridingSettings.musicPlayer.mute = !OverridingSettings.musicUnmuted;
        if (OverridingSettings.musicUnmuted)
        {
            musicButton.text = "Music: Unmuted";
        }
        else
        {
            musicButton.text = "Music: Muted";
        }
        MusicSetText();
    }

    public void FullscreenSetText()
    {
        Screen.fullScreen = OverridingSettings.fullscreenOn;
        if (OverridingSettings.fullscreenOn)
        {
            fullscreenButton.text = "Fullscreen: Fullscreen";
        }
        else
        {
            fullscreenButton.text = "Fullscreen: Windowed";
        }
    }

    public void SFXSetText()
    {
        if (OverridingSettings.sfxUnmuted)
        {
            sfxButton.text = "SFX: Unmuted";
        }
        else
        {
            sfxButton.text = "SFX: Muted";
        }
    }

    public void MusicSetText()
    {
        OverridingSettings.musicPlayer.mute = !OverridingSettings.musicUnmuted;
        if (OverridingSettings.musicUnmuted)
        {
            musicButton.text = "Music: Unmuted";
        }
        else
        {
            musicButton.text = "Music: Muted";
        }
    }
}
