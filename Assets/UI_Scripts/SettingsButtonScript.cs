using UnityEngine;

public class SettingsButtonScript : MonoBehaviour
{
    public GameObject settingsPanel;

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);  // Enable the settings panel
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);  // Close the settings panel
    }
}
