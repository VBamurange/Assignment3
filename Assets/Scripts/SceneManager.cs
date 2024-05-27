using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public Canvas titleCanvas;
    public Canvas settingsCanvas;
    public Slider volumeSlider;
    public Toggle notificationsToggle;
    public Dropdown resolutionDropdown;

    void Start()
    {
        ShowTitleCanvas();

        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);
        notificationsToggle.isOn = PlayerPrefs.GetInt("Notifications", 1) == 1;
        resolutionDropdown.value = PlayerPrefs.GetInt("Resolution", 0);

        resolutionDropdown.onValueChanged.AddListener(delegate { SaveSettings(); });
        notificationsToggle.onValueChanged.AddListener(delegate { OnNotificationsToggleChanged(); });
    }

    public void ShowTitleCanvas()
    {
        titleCanvas.gameObject.SetActive(true);
        settingsCanvas.gameObject.SetActive(false);
    }
    
    public void ShowSettingsCanvas()
    {
        titleCanvas.gameObject.SetActive(false);
        settingsCanvas.gameObject.SetActive(true);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.SetInt("Notifications", notificationsToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("Resolution", resolutionDropdown.value);
        PlayerPrefs.Save();
    }

    public void GoToSettings()
    {
        ShowSettingsCanvas();
    }

    public void GoBackToTitle()
    {
        SaveSettings();
        ShowTitleCanvas();
    }

    public void OnNotificationsToggleChanged()
    {
        if (notificationsToggle.isOn)
        {
            EnableNotifications();
        }
        else
        {
            DisableNotifications();
        }

        PlayerPrefs.SetInt("Notifications", notificationsToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void EnableNotifications()
    {
        Debug.Log("Notifications Enabled");
    }

    private void DisableNotifications()
    {
        Debug.Log("Notifications Disabled");
    }
    
}
