using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResolutionHandler : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    private List<Resolution> resolutions = new List<Resolution>();
    private int currentResolutionIndex = 0;

    void Start()
    {
        // Get all available resolutions
        resolutions = new List<Resolution>(Screen.resolutions);

        // Clear the dropdown options
        resolutionDropdown.ClearOptions();

        // Populate the dropdown with available resolutions
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Count; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            // Check if this is the player's current resolution
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height &&
                resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }

        // Add options to the dropdown
        resolutionDropdown.AddOptions(options);

        // Set the dropdown to the current resolution
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Add listener for dropdown value changes
        resolutionDropdown.onValueChanged.AddListener(delegate { SetResolution(resolutionDropdown.value); });
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, resolution.refreshRate);
        
        // Adjust the canvas if necessary, although the Canvas Scaler should handle this automatically
        // If you need to manually adjust anything on resolution change, you can do it here
    }
}
